using System.Collections.Generic;

namespace ConvertCmd.Core.Test
{
    public class TestSheetData 
    {

        public string SheetName { get; private set; }

        public string ExcelName { get; private set; }

        public Dictionary<int, TestVerifyData> VerifyDatas { get; private set; }

        public TestSheetData (string sheetName, string excelName)
        {
            SheetName = sheetName;
            ExcelName = excelName;
            VerifyDatas = new Dictionary<int, TestVerifyData> ();
        }


        public void ParseTestType (string[] testLine, string[] fields)
        {
            if (testLine == null)
            {
                return;
            }
            for (int i = 0; i < testLine.Length; i++)
            {
                var lineValue = testLine[i];
                if (lineValue == "TEST" || lineValue.IsNullOrEmptyOrWhiteSpace() || fields[i].IsNullOrEmptyOrWhiteSpace())
                {
                    continue;
                }

                TestVerifyData verifyData = new TestVerifyData();
                verifyData.owner = this;
                verifyData.Idx = i;
                verifyData.FieldName = fields[i];
                verifyData.TestInfo = lineValue;
                VerifyDatas.Add(i, verifyData);
            }
        }


        public void PushValuesInVerifyData (string[] lineValue)
        {
            foreach (var data in VerifyDatas)
            {
                data.Value.AddValues (lineValue);
            }
        }


        public void TestVerify (TestControl ctl)
        {
            foreach (var verifyData in VerifyDatas)
            {
                verifyData.Value.VerifyData(ctl);
            }
        } 


    }
}