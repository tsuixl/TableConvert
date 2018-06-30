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

namespace ConvertCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(args));
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            
            if (args.Length > 0)
            {
                try
                {
                    ArgsData data = JsonConvert.DeserializeObject<ArgsData>(args[0]);
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var type = Type.GetType("ConvertCmd.Core.Convert." + data.ConvertName);
                    var ins = assembly.CreateInstance("ConvertCmd.Core.Convert." + data.ConvertName, true);
                    type.GetMethod("StartConvert").Invoke(ins, new object[] { data });
                }
                catch (System.Exception)
                {
                    SystemUtil.Abend (string.Format("参数解析失败(路径不能有\\)\n{0}", args[0]));
                }
            }
            else
            {
                MoeConvertControl moeConvertCtl = new MoeConvertControl();
                var currentFolder = System.IO.Directory.GetCurrentDirectory();
                ArgsData data = new ArgsData ();
                data.ExcelPath = "../@ExcelTest";
                data.DesPath = "../@OutputLua";
                moeConvertCtl.StartConvert (data);
            }

        }

    }
}
