using System;
using ConvertCmd.Core;
using ConvertCmd.Core.Convert.Moe;
using ConvertCmd.Core.Language;
using ConvertCmd.Core.Reader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using ConvertCmd.Core.Util;
using ConvertCmd.Core.Test;
using System.Text.RegularExpressions;

namespace ConvertCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //  test json
            // string jsonStr = "{\"ExcelPath\":\"../../../excel\",\"DesPath\":\"../../../lua\",\"SelectFile\":false,\"Jenkins\":true,\"CustomConvert\":{\"LanguageSetting\":\"LanguageSplit\"},\"Test\":1}";
            // var tempData = Newtonsoft.Json.JsonConvert.DeserializeObject<ArgsData> (jsonStr);
            // Console.WriteLine(JsonConvert.SerializeObject(tempData));
            // return ;
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(args));
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            TestControl ctl = new TestControl();
            if (args.Length > 0)
            {
                ArgsData data = null;
                try
                {
                    data = JsonConvert.DeserializeObject<ArgsData>(args[0]);
                    SystemUtil.Content = data;
                }
                catch (System.Exception)
                {
                    SystemUtil.Abend (string.Format("参数解析失败(路径不能有\\)\n{0}", args[0]));
                }
                data.ConvertEvent = ctl;
                Assembly assembly = Assembly.GetExecutingAssembly();
                var type = Type.GetType("ConvertCmd.Core.Convert." + data.ConvertName);
                var ins = assembly.CreateInstance("ConvertCmd.Core.Convert." + data.ConvertName, true);
                type.GetMethod("StartConvert").Invoke(ins, new object[] { data });
            }
            else
            {
                MoeConvertControl moeConvertCtl = new MoeConvertControl();
                var currentFolder = System.IO.Directory.GetCurrentDirectory();
                ArgsData data = new ArgsData ();
                data.ConvertEvent = ctl;
                data.Jenkins = false;
                data.ExcelPath = "../@ExcelTest/Test";
                data.DesPath = "../@OutputLua/Test";
                data.CustomConvert = new System.Collections.Generic.Dictionary<string, string>();
                data.CustomConvert.Add("LanguageSetting", "LanguageSplit");
                // data.ExcelPath = "/Users/cc/Documents/eyu/slg/xfiles/number/excel";
                // data.DesPath = "/Users/cc/Documents/eyu/slg/xfiles/number/lua";
                SystemUtil.Content = data;

                moeConvertCtl.StartConvert (data);
            }

        }

    }
}
