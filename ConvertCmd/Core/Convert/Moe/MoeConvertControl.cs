using System.Collections.Generic;
using ConvertCmd.Core.Reader;
using System.IO;
using ConvertCmd.Core.Util;
using System.Text;

namespace ConvertCmd.Core.Convert.Moe
{
    public class MoeConvertControl : ConvertControlBase
    {
        protected override IExcelReader ExcelReader {get; set;}

        protected override IConvertTableHandle ConvertHandle { get; set;} 

        private string _srcAndDiagonal;

        private StringBuilder _loadTest;
        private StringBuilder _configTypes;

        private int _convertCount;

        public MoeConvertControl()
        {
            ExcelReader = new EPPlusReader();
            ConvertHandle = new MoeConvertTable();
            _loadTest = new StringBuilder(1024);
            _configTypes = new StringBuilder(1024);
        }

        protected override void _StartConvert (List<ExcelFileInfo> excelFiles)
        {
            if (ExcelSourceFolder.EndsWith("/"))
                _srcAndDiagonal = ExcelSourceFolder;
            else
                _srcAndDiagonal = ExcelSourceFolder + "/";

            if (IsRename(excelFiles))
            {
                return;
            }

            _convertCount = 0;
            _loadTest.Length = 0;
            _configTypes.Length = 0;

            foreach (var ef in excelFiles)
            {
                var relativeFilePath = ef.RelativePath;
                var suffix = ef.Suffix;
                var desFileName = string.Format("{0}/{1}/Moe{2}.lua", DesFolder, ef.RelativeDirectoryPath, ef.FileNameNoSuffix);
                var desFolder = Path.GetDirectoryName(desFileName);

                SystemUtil.Log( string.Format("Begin:\t{0}", relativeFilePath));
                var content = base.ConvertFile (ef.FullPath);
                SystemUtil.Log(string.Format("content == {0}", string.IsNullOrEmpty(content) ? "Empty": "HasValue"));
                if (!string.IsNullOrEmpty(content))
                {
                    SystemUtil.Log("SaveFile : "+ ef.FileNameNoSuffix);
                    SaveFile(desFolder, desFileName, content);
                    PushInTypes(ef);
                    PushInLoadTest(ef);
                    ++_convertCount;
                }

                SystemUtil.Log( string.Format("End:\t{0}", relativeFilePath));
                SystemUtil.Log("");
            }

            //  types
            var typeContent = Template.TemplateReplace.Replace("Template/MoeConfigType.txt", new Dictionary<string, string>()
            {
                {"$TYPE_CONTENT$", _configTypes.ToString()}
            });
            File.WriteAllText (DesFolder + "/MoeConfigType.lua", typeContent);

            //  tset
            _loadTest.AppendLine( string.Format("print(\"Load Finish! [{0}]\")", _convertCount));
            File.WriteAllText (DesFolder + "/_LuaLoadTest.lua", _loadTest.ToString());

            SystemUtil.Log("Convert Finish!");
            SystemUtil.Log("");

            ConvertHandle.EventHandel?.OnConvertFinish();
        }

        //  检测是否有重命名文件
        private bool IsRename(List<ExcelFileInfo> excelFiles)
        {
            HashSet<string> keys = new HashSet<string> (excelFiles.Count);
            foreach (var f in excelFiles)
            {
                var name = Path.GetFileNameWithoutExtension(f.FullPath);
                if (keys.Contains(name))
                {
                    SystemUtil.Abend (string.Format("表格有重命名! [{0}]", name));
                    return true;
                }
                keys.Add(name);
            }

            return false;
        }


        private void PushInTypes (ExcelFileInfo excelFileInfo)
        {
            // string fileName = Path.GetFileNameWithoutExtension(excelFileInfo.RelativePath);
            string luaPath = string.Empty;
            if (string.IsNullOrEmpty(excelFileInfo.RelativeDirectoryPath))
                luaPath = string.Format("{0}/Moe{1}", 
                                            excelFileInfo.RelativeDirectoryPath, 
                                            excelFileInfo.FileNameNoSuffix).Replace("/", "");
            else
                luaPath = string.Format("{0}/Moe{1}", 
                                            excelFileInfo.RelativeDirectoryPath, 
                                            excelFileInfo.FileNameNoSuffix).Replace("/", ".");
            _configTypes.AppendLine (string.Format("\t{0} = \"{1}\",", excelFileInfo.FileNameNoSuffix, luaPath));
        }


        private void PushInLoadTest (ExcelFileInfo excelFileInfo)
        {
            string luaPath = string.Empty;
            if (string.IsNullOrEmpty(excelFileInfo.RelativeDirectoryPath))
                luaPath = string.Format("{0}/Moe{1}", 
                                            excelFileInfo.RelativeDirectoryPath, 
                                            excelFileInfo.FileNameNoSuffix).Replace("/", "");
            else
                luaPath = string.Format("{0}/Moe{1}", 
                                            excelFileInfo.RelativeDirectoryPath, 
                                            excelFileInfo.FileNameNoSuffix).Replace("/", ".");

            var info = Template.TemplateReplace.Replace("Template/MoeLoadTestConfig.txt", new Dictionary<string, string> () {
                {"$MOE_RELATIVE_PATH$", luaPath},
                {"$MOE_FILE_NAME$", string.Format("Moe{0}", excelFileInfo.FileNameNoSuffix)},
                {"$FILE_NAME$", excelFileInfo.FileNameNoSuffix},
            });
            _loadTest.AppendLine(info);
        }


        private void SaveFile (string desFolder, string desFileName, string content)
        {
            if (!Directory.Exists (desFolder))
            {
                Directory.CreateDirectory(desFolder);
            }
            File.WriteAllText (desFileName, content);
        }
        
    }
}