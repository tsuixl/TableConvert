using System.IO;
using System.Collections.Generic;
using ConvertCmd.Core.Util;

namespace ConvertCmd.Core
{
    public class ExcelFileInfo
    {
        public string FullPath {get; protected set;}
        public string Suffix {get; protected set;}
        public string FileNameNoSuffix {get; protected set;}
        public string RelativePath {get; protected set;}
        public string RelativeDirectoryPath {get; protected set;}

        public ExcelFileInfo (string fullPath, string srcFolderHasDiagonal, string desFolder)
        {
            // var srcAndDiagonal = string.Empty;
            // if (srcFolder.EndsWith("/"))
            //     srcAndDiagonal = srcFolder;
            // else
            //     srcAndDiagonal = srcFolder + "/";

            FullPath = fullPath;
            FileNameNoSuffix = Path.GetFileNameWithoutExtension (fullPath);
            Suffix = Path.GetExtension(fullPath);
            RelativePath = fullPath.Replace("\\","/").Replace(srcFolderHasDiagonal, string.Empty);
            RelativeDirectoryPath = Path.GetDirectoryName(RelativePath);
        }
    }

    public abstract class ConvertControlBase
    {
        protected abstract IExcelReader ExcelReader {get; set;}

        protected abstract IConvertTableHandle ConvertHandle { get; set; } 

        protected string DesFolder;
        protected string ExcelSourceFolder;

        public void StartConvert (ArgsData args)
        {
            System.Console.WriteLine (string.Format("Excel Folder : {0}", args.ExcelPath));
            System.Console.WriteLine (string.Format("Des Folder : {0}", args.DesPath));

            DesFolder = new DirectoryInfo (args.DesPath).FullName.Replace("\\", "/");
            ExcelSourceFolder = new DirectoryInfo (args.ExcelPath).FullName.Replace("\\", "/");

            if (string.IsNullOrEmpty(ExcelSourceFolder))
            {
                throw new System.ArgumentException ("excelFolder 不存在!");
            }

            if (string.IsNullOrEmpty(DesFolder))
                throw new System.ArgumentException ("desFolder 为空!");

            if (!Directory.Exists(DesFolder))
            {
                Directory.CreateDirectory(DesFolder);
            }

            //  导出选择文件,不能清理目录
            if (args.SelectFile)
                args.ClearDes = false;

            if (args.ClearDes && Directory.Exists(DesFolder))
            {
                var folders = Directory.GetDirectories(DesFolder);
                foreach (var fol in folders)
                {
                    if (fol.EndsWith(".svn"))
                    {
                        continue;
                    }
                    Directory.Delete(fol, true);
                }
            }
            else
                Directory.CreateDirectory(DesFolder);

            var srcAndDiagonal = string.Empty;
            if (ExcelSourceFolder.EndsWith("/"))
                srcAndDiagonal = ExcelSourceFolder;
            else
                srcAndDiagonal = ExcelSourceFolder + "/";

            var files = Directory.GetFiles (ExcelSourceFolder, "*.xlsx", SearchOption.AllDirectories);
            var excelFileInfos = new List<ExcelFileInfo> ();
            foreach (var f in files)
            {
                if (f.Contains("~$"))
                    continue;
                excelFileInfos.Add(new ExcelFileInfo(f, srcAndDiagonal, DesFolder));
            }

            if (args.SelectFile)
            {
                excelFileInfos = UserSelect(excelFileInfos);
            }

            _StartConvert (excelFileInfos);

            System.Console.WriteLine (string.Format("Excel Folder : {0}", ExcelSourceFolder));
            System.Console.WriteLine (string.Format("Des Folder : {0}", DesFolder));
        }


        protected abstract void _StartConvert (List<ExcelFileInfo> excelFiles);


        protected string ConvertFile (string excelFilePath)
        {
            var exInfo = ExcelReader.Load (excelFilePath);
            if (exInfo == null)
            {
                ConvertHandle.ConvertStart(ExcelReader);
                foreach (ISheetReader sheetReader in ExcelReader)
                {
                    ConvertHandle.ConvertSheet(sheetReader);
                }
                ConvertHandle.ConvertFinish(ExcelReader);
                return ConvertHandle.GetContent();
            }
            else
            {
                SystemUtil.Print (exInfo);
            }
            return string.Empty;
        }


        protected List<ExcelFileInfo> UserSelect (List<ExcelFileInfo> fileInfo)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder(32);
            for (int i = 0; i < fileInfo.Count; i++)
            {
                result.AppendLine(string.Format("[{0}]\t{1}", i, fileInfo[i].RelativePath));
            }
            result.AppendLine("请选择要导出的文件,以,分割!!");
            var selectData = UserInputUtil.ReadLineData(result.ToString());
            if (string.IsNullOrEmpty(selectData))
            {
                return fileInfo;
            }

            List<int> selectIndex = new List<int>();
            selectData = selectData.Trim();
            var numbers = selectData.Split(",");
            foreach (var n in numbers)
            {
                int index ;
                if (int.TryParse(n, out index))
                {
                    if (index >= 0 && index < fileInfo.Count)
                    {
                        selectIndex.Add(index);
                    }
                }
            }
            selectIndex.Sort ();

            List<ExcelFileInfo> resultFileInfo = new List<ExcelFileInfo>();
            for (int i = selectIndex.Count - 1; i >= 0 ; i--)
            {
                resultFileInfo.Add(fileInfo[selectIndex[i]]);
            }

            return resultFileInfo;
        }
        
    } 
}