namespace ConvertCmd.Core.Util
{
    public class UserInputUtil
    {
        public static string ReadLineData (string info)
        {
            SystemUtil.Log(info);
            return System.Console.ReadLine();
        }
    }
}