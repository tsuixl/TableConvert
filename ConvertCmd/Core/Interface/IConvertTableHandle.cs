namespace ConvertCmd.Core
{
    public interface IConvertTableHandle
    {
        ConvertExceptionInfo ConvertStart (IExcelReader excelReader);

        ConvertExceptionInfo ConvertSheet (ISheetReader sheetReader);

        ConvertExceptionInfo ConvertFinish (IExcelReader excelReader);

        string GetContent ();
    }
}