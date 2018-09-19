using ConvertCmd.Core.Util;
using System.Collections.Generic;

namespace ConvertCmd.Core.Test
{
    public class TestControl : IConvertEvent
    {
        private TestExcelData _tempExcelData;
        private Dictionary<string, TestExcelData> _excelMaps;


        public TestControl ()
        {
            _excelMaps = new Dictionary<string, TestExcelData>();
        }


        public bool HasExcel (string excelName)
        {
            return _excelMaps.ContainsKey(excelName);
        }

        public bool HasExcelKey (string excelName, string key)
        {
            TestExcelData excelData = null;
            if (_excelMaps.TryGetValue(excelName, out excelData))
            {
                return excelData.ContainKey(key);
            }
            return false;
        }


        public void OnConvertExcelEnd(string excelName)
        {
        }

        public void OnConvertExcelStart(string excelName)
        {
            excelName = System.IO.Path.GetFileNameWithoutExtension (excelName);
            _tempExcelData = new TestExcelData(excelName);
            _excelMaps.Add(excelName, _tempExcelData);
        }

        public void OnConvertSheetEnd(string sheetName)
        {
            _tempExcelData.EndSheet();
        }

        public void OnConvertSheetLine(int row, string[] lineData)
        {
            _tempExcelData.ParseLineData(lineData);
        }

        public void OnConvertSheetStart(string sheetName, ISheetReader reader)
        {
            _tempExcelData.NewSheet(sheetName, reader.GetLineCell(5), reader.GetLineCell(3));
        }

        public void OnConvertFinish ()
        {
            StartTest();
        }


        public void StartTest ()
        {
            SystemUtil.LogTest("---------------开始检查表格");
            SystemUtil.NewLine();
            foreach (var excelData in _excelMaps)
            {
                excelData.Value.StartTest(this);
            }
            SystemUtil.NewLine();
            SystemUtil.LogTest("其余没有数据,不再输出日志~!");
            SystemUtil.LogTest("---------------结束检查表格");
        }

    }
}