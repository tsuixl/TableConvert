using System.Collections.Generic;
using ConvertCmd.Core.Util;

namespace ConvertCmd.Core
{
    public class ConvertControl 
    {   
        private IExcelReader _excelReader;
        private IConvertTableHandle _convertHandle;

        public ConvertControl (IConvertTableHandle convertHandle, IExcelReader excelReader)
        {
            _excelReader = excelReader;
            _convertHandle = convertHandle;
        }
        

        public void ConvertFile (string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Util.SystemUtil.Abend ("filePath == null");
            }

            if (filePath.Contains("~$"))
                return;

            if (filePath.Contains("TemplateSetting"))
            {
                int i = 0;
                ++i;
            }

            var exInfo = _excelReader.Load (filePath);
            if (exInfo == null)
            {
                _convertHandle.ConvertStart(_excelReader);
                foreach (ISheetReader sheetReader in _excelReader)
                {
                    _convertHandle.ConvertSheet(sheetReader);
                }
                _convertHandle.ConvertFinish(_excelReader);
            }
            else
            {
                SystemUtil.Print (exInfo);
            }
        }
        
    }
}