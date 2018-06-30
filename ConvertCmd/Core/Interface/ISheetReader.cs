namespace ConvertCmd.Core
{
    public interface ISheetReader
    {
        int StartRow {get;}

        int StartCol {get;}

        int MaxRow {get;}

        int MaxCol {get;}

        int GetTotalLine ();
        
        string GetSheetName ();

        string GetCell (int row, int col);

        string[] GetLineCell (int line);
    }
}