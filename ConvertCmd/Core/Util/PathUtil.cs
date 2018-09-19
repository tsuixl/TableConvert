using System.IO;


namespace ConvertCmd.Core.Util
{
    public static class PathUtil
    {
        public static string RealPath (string path)
        {
            if (path.StartsWith("../"))
            {
                return string.Format("{0}/{1}", Directory.GetCurrentDirectory(), path);
            }
            else if (path.StartsWith("/.."))
            {
                return string.Format("{0}{1}", Directory.GetCurrentDirectory(), path);
            }
            return path;
        }
    }
}