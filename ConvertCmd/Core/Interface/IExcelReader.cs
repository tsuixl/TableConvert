
using System.Collections;
using System.Collections.Generic;
namespace ConvertCmd.Core
{
    public interface IExcelReader : IEnumerator, IEnumerable, IEnumerator<ISheetReader>
    {

        int SheetCount {get;}

        string ExcelName {get;}

        string FullFilePath { get; }      

        ConvertExceptionInfo Load (string filePath);  
    }
}