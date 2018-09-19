using OfficeOpenXml;

namespace ConvertCmd.Core.Reader
{
    public class EPPlusSheetReader : ISheetReader
    {

        private ExcelWorksheet _workSheet;
        private int _maxRow, _maxCol, _startRow, _startCol;

        public int StartRow => _startRow;

        public int StartCol => _startCol;

        public int MaxRow => _maxRow;

        public int MaxCol => _maxCol;

        public void ResetSheet (ExcelWorksheet sheet)
        {
            _workSheet = sheet;
            _startRow = _workSheet.Dimension.Start.Row;
            _startCol = _workSheet.Dimension.Start.Column;
            _maxRow = _workSheet.Dimension.End.Row;
            _maxCol = _workSheet.Dimension.End.Column;
        }

        public string GetCell(int row, int col)
        {
            var obj = _workSheet.Cells[row, col];
            if (obj == null || obj.Value == null)
                return string.Empty;
            return obj.Value.ToString();
        }

        public string[] GetLineCell(int row)
        {
            var maxCol = MaxCol;
            if (maxCol == -1)
                return null;

            if (!HasRow(row))
                return null;

            string[] result = new string[MaxCol];
            int index = 0;
            for (int i = StartCol; i <= maxCol; i++)
            {
                var obj = _workSheet.Cells[row, i].Value;
                if (obj == null)
                    result[index] = string.Empty;
                else
                    result[index] = obj.ToString();
                ++index;
            }

            return result;
        }

        public string GetSheetName()
        {
            return _workSheet.Name;
        }

        public int GetTotalLine()
        {
            return MaxRow - StartRow + 1;
        }

        public bool HasRow (int row)
        {
            return row >= StartRow && row <= MaxRow;
        }

        public bool HasCol (int col)
        {
            return col >= StartCol && col <= MaxCol;
        }


        public bool HasFirst (string firstKey, int maxLine = 10)
        {
            return FindLineByFirst(firstKey, maxLine) != -1;
        }

        public int FindLineByFirst (string firstKey, int maxLine = 10)
        {
            int max = System.Math.Clamp (maxLine, 1, _maxRow);
            if (StartRow > max)
                return -1;

            for (int i = StartRow; i < max; i++)
            {
                var v = GetCell (i, StartCol);
                if (v == firstKey)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}