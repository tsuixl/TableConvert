using System.IO;
using ConvertCmd.Core.Util;
using System.Collections.Generic;

namespace ConvertCmd.Core.Template
{
    public class TemplateReplace
    {
        public static string Replace (string fileName, Dictionary<string, string> replaceInfo)
        {
            if (!File.Exists(fileName))
            {
                SystemUtil.Abend(string.Format("模板文件[{0}]加载失败!",fileName));
                return string.Empty;
            }

            string templateInfo = File.ReadAllText(fileName);
            foreach (var item in replaceInfo)
            {
                templateInfo = templateInfo.Replace(item.Key, item.Value);
            }
            return templateInfo;
        }
    }
}