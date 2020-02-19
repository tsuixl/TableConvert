using ConvertCmd.Core;
using ConvertCmd.Core.Util;
using ConvertCmd.Core.Enum;
using System.Collections.Generic;
using ConvertCmd.Core.Language;
using Newtonsoft.Json.Linq;
using ConvertCmd.Core.Template;
using ConvertCmd.Core.Convert.Moe;
using ConvertCmd.Core.Convert;
using System.Text.RegularExpressions;

public class LanguageSplit : IConvertTableHandle
{
    private static int START_ROW = 5;

    public class ColInfo 
    {
        public string Field;

        public System.Text.StringBuilder Txt;

        public int Count;

        public ColInfo ()
        {
            Field = string.Empty;
            Txt = new System.Text.StringBuilder (1024);
        }
    }


    private int _convertCount;
    private int _defLength;
    private string _excelName;
    private string _sheetName;
    private ClientDef _mainKeyDef;
    private JsonToLua _jsonToLua;
    // private System.Text.StringBuilder _excelTxt;
    private SortedDictionary<int, ClientDef> _sheetClientDefs;
    private HashSet<string> _mainKeyRecords;

    private Dictionary<string, ColInfo> _colInfo;

    public IConvertEvent EventHandel { get; set; }

    public LanguageSplit()
    {
        _jsonToLua = new JsonToLua();
        _mainKeyRecords = new HashSet<string>();
        // _excelTxt = new System.Text.StringBuilder(1024);
        _colInfo = new Dictionary<string, ColInfo>();
        _sheetClientDefs = new SortedDictionary<int, ClientDef>(
            new CustomComparer<int>((l, r) => { return l.CompareTo(r); })
        );
    }


    public ConvertExceptionInfo ConvertStart(IExcelReader excelReader)
    {
        _defLength = -1;
        _convertCount = 0;
        _excelName = excelReader.ExcelName;
        _mainKeyRecords.Clear();
        _sheetClientDefs.Clear();
        _jsonToLua.ResetCache();
        _colInfo.Clear();
        EventHandel?.OnConvertExcelStart(excelReader.ExcelName);
        return null;
    }

    public ConvertExceptionInfo ConvertFinish(IExcelReader excelReader)
    {
        if (_convertCount > 0)
        {
            foreach (var item in _colInfo)
            {
                var colInfo = item.Value;
                
                var name = string.Format("MoeLanguage{0}", item.Key);
                var content = colInfo.Txt.ToString();
                colInfo.Txt.Length = 0;
                colInfo.Txt.Append(TemplateReplace.Replace("Template/MoeConfig.txt", new Dictionary<string, string>()
                {
                    {"$TABLE_NAME$", name},
                    {"$TABLE_CONUT$", colInfo.Count.ToString()},
                    {"$TABLE_CONTENTS$", content},
                }));
                SystemUtil.Log(string.Format("Convert Count : [{0}], {1}", colInfo.Count, name));
            }
        }
        else
        {
            SystemUtil.Wran("[该表没有任何数据可以导出!]");
        }
        EventHandel?.OnConvertExcelEnd(_excelName);
        return null;
    }

    public ConvertExceptionInfo ConvertSheet(ISheetReader sheetReader)
    {
        _sheetName = sheetReader.GetSheetName();
        //  1. 分页第一行第一列是否有值
        var firstValue = sheetReader.GetCell(1, 1);
        if (string.IsNullOrEmpty(firstValue.ToString()))
        {
            SystemUtil.Wran(string.Format("SheetName [{0}] 不导出!", sheetReader.GetSheetName()));
            return null;
        }

        //  2. 检查客户端字段以及类型定义
        var error = DetectionFourLine(sheetReader.GetLineCell(1), sheetReader.GetLineCell(2), sheetReader.GetLineCell(3));
        if (error != null)
        {
            SystemUtil.Print(error);
            if (error.InfoType == ExceptionInfoType.Warn)
                return null;
        }

        //  Event
        EventHandel?.OnConvertSheetStart(_sheetName, sheetReader);

        int currentRow = START_ROW;
        //  Test
        if (sheetReader.HasFirst("TEST"))
        {
            currentRow++;
        }


        bool isBreak = false;
        string[] lineData = null;

        while (true)
        {
            if (isBreak)
            {
                //  结束
                break;
            }

            //  执行行命令
            var lineCmd = ParseCmd(sheetReader.GetCell(currentRow, sheetReader.StartCol));
            if (lineCmd == LineCmd.Ignore)
            {
                ++currentRow;
                continue;
            }
            else if (lineCmd == LineCmd.End)
                isBreak = true;

            //  获取行数据
            lineData = sheetReader.GetLineCell(currentRow);
            if (lineData == null)
            {
                isBreak = true;
                if (currentRow == START_ROW)
                    SystemUtil.Wran(ContentInfo("分页为空,不导出!"));
                else
                    SystemUtil.Wran(ContentInfo(string.Format("({0})行数据为空,自动跳出!", currentRow)));
                continue;
            }

            //  导出为lua
            ParseLine(lineData, currentRow);
            EventHandel?.OnConvertSheetLine(currentRow, lineData);
            ++_convertCount;
            ++currentRow;
        }

        EventHandel?.OnConvertSheetEnd(_sheetName);

        SystemUtil.Log(ContentInfo("Finish!"), System.ConsoleColor.Green);
        return null;
    }


    private void ParseLine(string[] lineData, int currentRow)
    {
        //  导出为lua
        var mainKey = lineData[1];
        if (string.IsNullOrEmpty(mainKey) || string.IsNullOrWhiteSpace(mainKey))
        {
            SystemUtil.Abend(ContentInfo(string.Format("({0})行主键为空~!", currentRow)));
            return;
        }
      
        var mainKeyStr = string.Empty;
        if (_mainKeyDef.ValueType == ValueType.String)
        {
            mainKeyStr = string.Format("\t[\"{0}\"] = {{", mainKey);
        }
        else
        {
            mainKeyStr = string.Format("\t[{0}] = {{", mainKey);
        }

        if (_mainKeyRecords.Contains(mainKey))
        {
            SystemUtil.Abend(ContentInfo(string.Format("({0})行主键重复!", currentRow)));
        }
        _mainKeyRecords.Add(mainKey);

        int lineDataCount = lineData.Length;
        foreach (var item in _sheetClientDefs)
        {
            if (item.Key <= 1)
            {
                continue;
            }

            if (!_colInfo.ContainsKey(item.Value.Comments))
            {
                _colInfo.Add(item.Value.Comments, new ColInfo());
            }

            var colInfo = _colInfo[item.Value.Comments];

            colInfo.Txt.AppendLine(mainKeyStr);

            string colValue = string.Empty;
            if (item.Key < lineDataCount)
                colValue = lineData[item.Key].ToString();

            colInfo.Count++;
            colInfo.Txt.Append(_jsonToLua.ConvertString(item.Value.Field, colValue, item.Value.ValueType, 2, mainKey));
            colInfo.Txt.AppendLine(",");
            colInfo.Txt.AppendLine("\t},\n");
        }
    }


    private LineCmd ParseCmd(string cellData)
    {
        string str = cellData.ToLower();
        if (string.IsNullOrEmpty(str))
            return LineCmd.None;

        if (str == "end")
            return LineCmd.End;
        else if (str == "no")
            return LineCmd.Ignore;
        return LineCmd.None;
    }

    public ConvertExceptionInfo DetectionFourLine(string[] comments, string[] types, string[] clientFields)
    {
        if (comments.Length < 2 || types.Length < 2 || clientFields.Length < 2)
        {
            return ConvertExceptionInfo.Warn(string.Format("{0}-({1}),格式不正确,忽略该分页!", _excelName, _sheetName));
        }

        if (!IsType("TYPE", types))
            return ConvertExceptionInfo.Warn(ContentInfo("第二行第一列应为TYPE,忽略该分页! " + _defLength));

        if (!IsType("CLIENT", clientFields))
            return ConvertExceptionInfo.Warn(ContentInfo("第三行第一列应为CLIENT,忽略该分页!"));


        //  客户端类型
        _sheetClientDefs.Clear();
        int defLength = 0;
        for (int i = 0; i < clientFields.Length; i++)
        {
            var field = clientFields[i];
            // var str = field == null ? "" : field.ToString();
            if (i == 0 || string.IsNullOrEmpty(field))
                continue;


            string typeStr = string.Empty;
            if (i < types.Length)
                typeStr = types[i];
            else
            {
                SystemUtil.Abend(string.Format("{0}-({1})-({2},{3}), [{4}]字段,没有填写类型!",
                                _excelName,
                                _sheetName,
                                3,
                                i + 1,
                                field));
            }

            var valueType = ValueTypeUtil.String2ValueType(typeStr);
            if (valueType == ValueType.None)
            {
                SystemUtil.Abend(string.Format("{0}-({1})-({2},{3}), 类型不存在! {4}",
                                _excelName,
                                _sheetName,
                                2,
                                i + 1,
                                valueType));
            }

            ClientDef def = new ClientDef();
            def.Field = field;
            def.ValueType = valueType;
            def.Comments = comments[i];

            if (def.Comments.IsNullOrEmptyOrWhiteSpace())
            {
                SystemUtil.Abend(string.Format("{0}-({1})-({2},{3}), 注释为空!",
                                _excelName,
                                _sheetName,
                                2,
                                i + 1));
            }
            else
            {
                def.Comments = MatchLanguageStr (def.Comments);
            }

            //  主键类型缓存
            if (i == 1)
            {
                _mainKeyDef.Field = def.Field;
                _mainKeyDef.ValueType = def.ValueType;
            }

            _sheetClientDefs.Add(i, def);
            ++defLength;
        }

        if (defLength < 1)
        {
            return ConvertExceptionInfo.Warn(ContentInfo("该分页没有定义客户端字段,忽略该分页!"));
        }
        // else if (_defLength != -1 && _defLength != defLength)
        // {
        //     SystemUtil.Abend (ContentInfo (string.Format("分页之间,客户端字段数量不匹配! {0} : {1}", _defLength, defLength)));
        // }

        if (_defLength == -1)
        {
            _defLength = defLength;
        }
        return null;
    }

    ContentData IConvertTableHandle.GetContent()
    {
        if (_convertCount == 0)
        {
            _colInfo.Clear();
            return null;
        }

        ContentData data = new ContentData();
        data.DefaultContent = string.Empty;
        data.CustomContent = new Dictionary<string, string>(_colInfo.Count);
        foreach (var item in _colInfo)
        {
            data.CustomContent.Add(string.Format("Language{0}", item.Key), item.Value.Txt.ToString());
        }

        return data;
    }


    public string MatchLanguageStr (string commons)
    {
        Regex reg = new Regex(@"(?<=\()\S+(?=\))");
        var match = reg.Match (commons);
        return match.Value;
    } 

    public bool IsType(string typeName, object[] lineData)
    {
        typeName = typeName.ToLower();
        var lineTypeName = lineData[0].ToString();
        if (typeName == lineTypeName.ToLower())
            return true;
        return false;
    }


    private string ContentInfo(string info)
    {
        return string.Format("[{0}]-({1})-{2}", _excelName, _sheetName, info);
    }
}