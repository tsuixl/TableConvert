using ConvertCmd.Core.Util;

namespace ConvertCmd.Args
{
    public static class ArgsHelp
    {
        public static object ParseArgs (string arg, System.Type t)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject (arg, t);
            }
            catch (System.Exception)
            {
                SystemUtil.Abend (string.Format("参数解析失败! [{0}]", arg));
            }
            
            return null;
        }
    }
}