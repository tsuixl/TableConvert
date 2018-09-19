using System.Collections.Generic;
using ConvertCmd.Core.Util;

namespace ConvertCmd.Core.Test
{
    public class TestExcelData 
    {
        public string ExcelName { get; set; }

        public HashSet<string> Keys { get; set; }

        public List<TestSheetData> SheetDatas { get; set; }


        private TestSheetData _tempSheetData;


        public TestExcelData()
        {
            Keys = new HashSet<string>();
            SheetDatas = new List<TestSheetData>();
        }


        public TestExcelData (string excelName) 
        {
            ExcelName = excelName;
            Keys = new HashSet<string>();
            SheetDatas = new List<TestSheetData>();
        }


        public bool ContainKey (string key)
        {
            return Keys.Contains(key);
        }


        public void NewSheet (string sheetName, string[] types, string[] fields)
        {
            if (types == null || types.Length == 0)
                return;

            if (types[0] != "TEST")
                return;

            TestSheetData sheetData = new TestSheetData (sheetName, ExcelName);
            _tempSheetData = sheetData;
            _tempSheetData.ParseTestType(types, fields);
            SheetDatas.Add(sheetData);
        }


        public void ParseLineData (string[] lineData)
        {
            if (_tempSheetData != null)
            {
                _tempSheetData.PushValuesInVerifyData(lineData);
            }

            //  add key
            if (lineData.Length > 1)
            {
                if (!Keys.Contains(lineData[1]))
                {
                    Keys.Add(lineData[1]);
                }
            }
        }

        public void EndSheet ()
        {
            _tempSheetData = null;
        }


        public void StartTest(TestControl ctl)
        {
            if (SheetDatas.Count == 0)
            {
                // SystemUtil.LogTest(string.Format("[{0}] 没有数据!", ExcelName));
                return;
            }

            SystemUtil.LogTest("");
            SystemUtil.LogTest(string.Format("[{0}] Test Start", ExcelName));
            for (int i = 0; i < SheetDatas.Count; i++)
            {
                var sheetData = SheetDatas[i];
                // SystemUtil.LogTest (string.Format("    ({0}) Start", sheetData.SheetName));
                sheetData.TestVerify (ctl);
                // SystemUtil.LogTest (string.Format("    ({0}) End", sheetData.SheetName));
            }
            SystemUtil.LogTest(string.Format("[{0}] Test END", ExcelName));
            SystemUtil.LogTest("");
        }


        // public TestVerifyData CreateSheetData (string sheetName)
        // {
        //     var newData = new TestVerifyData();
        // }


        // public void AddValueInData (string fieldName, int idx, string value)
        // {
        //     TestVerifyData data = null;
        //     if (VerifyDatas.TryGetValue(fieldName, out data))
        //     {
        //         data.AddInValue(value);
        //     }
        //     else
        //     {
        //         data = new TestVerifyData (fieldName, idx);
        //         data.AddInValue(value);
        //         VerifyDatas.Add(data.GetMainKey(), data);
        //     }
        // }


        // public void CreateVerifyData (string fieldName, int idx)
        // {
        //     if (!VerifyDatas.ContainsKey(GetMainKey(fieldName, idx)))
        //     {
        //         VerifyDatas.Add(GetMainKey(fieldName, idx), new TestVerifyData (fieldName, idx));
        //     }
        // }


        // public string GetMainKey (string fieldName, int idx)
        // {
        //     return string.Format("{0}-{1}", fieldName, idx);
        // }

    }
}