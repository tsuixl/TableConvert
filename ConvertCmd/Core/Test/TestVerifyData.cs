using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ConvertCmd.Core.Util;

namespace ConvertCmd.Core.Test
{
    public class TestVerifyData
    {
        public int Idx { get; set; }

        public string FieldName { get; set; }

        public string TestInfo { get; set; }

        public List<string> Values { get; set; }

        internal TestSheetData owner;

        public TestVerifyData()
        {
            Values = new List<string> ();
        }

        public void AddValues (string [] lineDatas)
        {
            if (Idx < lineDatas.Length)
            {
                Values.Add(lineDatas[Idx]);
            }
        }

        public void VerifyData (TestControl ctl)
        {
            JToken token = null;
            try
            {
                token = JToken.Parse (TestInfo);
            }
            catch (System.Exception)
            {
                SystemUtil.KillApp(string.Format("Json解析异常 [{0}]", TestInfo));
            }

            if (token.Type == JTokenType.Object)
            {
                foreach (var item in token)
                {
                    if (item.Type == JTokenType.Property)
                    {
                        var propertyItem = item as JProperty;
                        if (propertyItem.Name == "Ref")
                        {
                            ParseRef (propertyItem, ctl);
                        }
                    }
                }
            }
            
        }

        public void ParseRef (JProperty jProperty, TestControl ctl)
        {
            JArray array = jProperty.Value as JArray;
            List<string> excelNames = new List<string>();
            if (array != null)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    var data = array[i];
                    var excelName = data.Value<string>();
                    excelNames.Add(excelName);
                }
            }

            foreach (var name in excelNames)
            {
                if (!ctl.HasExcel (name))
                {
                    SystemUtil.LogTestError(string.Format("({0}) 该表格不存在!", name), 4);
                    continue;
                }
                int idx = 5;
                foreach (var v in Values)
                {
                    idx ++;
                    var listValue = ParseMultiValues (v);

                    if (listValue == null)
                    {
                        if (!ctl.HasExcelKey(name, v))
                        {
                            SystemUtil.LogTestError(string.Format("{0}.{1}.{2}.[{3}] ({4}行) 不存在于 [{5}] 中!",
                                                        owner.ExcelName,
                                                        owner.SheetName,
                                                        FieldName,
                                                        v,
                                                        idx,
                                                        name),
                                                         4);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listValue.Count; i++)
                        {
                            var lv = listValue[i];

                            if (!ctl.HasExcelKey(name, lv))
                            {
                                SystemUtil.LogTestError(string.Format("{0}.{1}.{2}.[{3}] ({4}行) 不存在于 [{5}] 中!",
                                                            owner.ExcelName,
                                                            owner.SheetName,
                                                            FieldName,
                                                            lv,
                                                            idx,
                                                            name)
                                                            , 4);
                            }
                        }
                    }
                    
                }
            }
        }

        private List<string> ParseMultiValues (string info)
        {
            double v; 
            
            if (double.TryParse (info, out v))
            {
                return null;
            }

            List<string> result = new List<string>();

            if (info.IsNullOrEmptyOrWhiteSpace())
            {
                return result;
            }

            var token = JToken.Parse (info);
            if (token.Type == JTokenType.Array)
            {
                var array = token as JArray;
                for (int i = 0; i < array.Count; i++)
                {
                    var data = array[i];
                    if (data.Type == JTokenType.Float || 
                        data.Type == JTokenType.Integer || 
                        data.Type == JTokenType.String)
                    {
                        result.Add(data.ToString());
                    }
                }
            }
            else
            {
                SystemUtil.LogTestError (string.Format("{0}.{1}.{2} 检测失败(不支持该数据类型检测)", 
                                                    owner.ExcelName, 
                                                    owner.SheetName, 
                                                    FieldName
                                                    ), 4);
            }

            return result;
        }


    }   
}