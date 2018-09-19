namespace ConvertCmd.Core
{
    [System.Serializable]
    public class ArgsData
    {
        public string DesPath { get; set;}

        public string ExcelPath {get; set;}

        public string ConvertName {get; set;}

        public bool ClearDes {get; set;}

        public bool SelectFile {get; set;}

        public bool Jenkins  { get; set;}

        public IConvertEvent ConvertEvent { get; set; }
        
        public ArgsData ()
        {
            ClearDes = true;
            SelectFile = false;
            ConvertName = "Moe.MoeConvertControl";
        }
    }
}