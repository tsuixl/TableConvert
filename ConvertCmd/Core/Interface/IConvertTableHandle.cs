namespace ConvertCmd.Core
{
    public interface IConvertTableHandle
    {

        IConvertEvent EventHandel { get; set;}

        ConvertExceptionInfo ConvertStart (IExcelReader excelReader);

        ConvertExceptionInfo ConvertSheet (ISheetReader sheetReader);

        ConvertExceptionInfo ConvertFinish (IExcelReader excelReader);

        ContentData GetContent ();
    }
}