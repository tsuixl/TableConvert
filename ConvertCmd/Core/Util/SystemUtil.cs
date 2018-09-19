using System;

namespace ConvertCmd.Core.Util
{
    public static class SystemUtil
    {
        public static ArgsData Content;

        public static void Abend (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Error);
            WriteLine(info, 0);
            Console.ForegroundColor = ConsoleColor.White;
            KillApp (info);
        }


        public static void Log (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Info);
            WriteLine(info, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void LogTest (string info, int spacing = 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine (info, spacing);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void LogTestError (string info, int spacing = 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine (info, spacing);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void WriteLine (string info, int spacing)
        {
            if (spacing <= 0)
            {
                if (Content.Jenkins)
                {
                    Console.WriteLine(string.Format(GetJenkinsColor(Console.ForegroundColor), info));
                }
                else
                {
                    Console.WriteLine (info);
                }
            }
            else
            {
                var str = string.Format("{0}{1}", GetSpacing(spacing), info);
                if (Content.Jenkins)
                {
                    str = string.Format(GetJenkinsColor(Console.ForegroundColor), info);
                }
                Console.WriteLine(str);
            }
        }


        public static void Wran (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Warn);
            WriteLine(info, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Print(ConvertExceptionInfo info)
        {
            Console.ForegroundColor = GetColor(info.InfoType);
            WriteLine(info.Info, 0);
            Console.ForegroundColor = ConsoleColor.White;
            if (info.InfoType == ExceptionInfoType.Error)
            {
                KillApp(info.Info);
            }
        }


        public static void KillApp(string info)
        {
            if (Content.Jenkins)
            {
                info = string.Format(@"\e[31m{0}\e[0m\n", 31, info);
            }
            
            throw new System.Exception (info);
        }


        public static void Log (string info, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            // Console.WriteLine(info);
            WriteLine(info, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void NewLine ()
        {
            Console.WriteLine("");
        }


        private static System.Text.StringBuilder _temp = new System.Text.StringBuilder(16);
        public static string GetSpacing (int count)
        {
            _temp.Length = 0;
            for (int i = 0; i < count; i++)
            {
                _temp.Append(" ");
            }
            return _temp.ToString();
        }


        public static ConsoleColor GetColor (ExceptionInfoType infoType)
        {
            if (infoType == ExceptionInfoType.Error)
                return ConsoleColor.Red;
            else if (infoType == ExceptionInfoType.Warn)
                return ConsoleColor.Yellow;
            else
                return ConsoleColor.White;
        }


        public static string GetJenkinsColor (ConsoleColor color)
        {
            // if (color == ConsoleColor.Red)
            // {
            //     return @"\e[31m{0}\e[0m" ;
            // }
            // else if (color == ConsoleColor.Yellow)
            // {
            //     return @"\e[33m{0}\e[0m" ;
            // }
            // else if (color == ConsoleColor.Green)
            // {
            //     return @"\e[32m{0}\e[0m" ;
            // }
            // else if (color == ConsoleColor.Blue)
            // {
            //     return @"\e[34m{0}\e[0m" ;
            // }
            // else
            // {
            //     return @"\e[37m{0}\e[0m" ;
            // }
            return "{0}";
        }
    }
}