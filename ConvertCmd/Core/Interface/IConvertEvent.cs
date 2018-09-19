namespace ConvertCmd.Core
{
    public interface IConvertEvent
    {
        void OnConvertExcelStart (string excelName);

        void OnConvertExcelEnd (string excelName);

        void OnConvertSheetStart (string sheetName, ISheetReader sheetReader);

        void OnConvertSheetLine (int row, string[] lineData);

        void OnConvertSheetEnd (string sheetName);

        void OnConvertFinish ();
    }
}
