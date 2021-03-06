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
            System.Environment.Exit(100);
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


        public static void Error (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Error);
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
            Error (info);
            System.Environment.Exit(100);
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
            int c = 37;
            if (color == ConsoleColor.Red)
            {
                c = 31;
            }
            else if (color == ConsoleColor.Yellow)
            {
                c = 33;
            }
            else if (color == ConsoleColor.Green)
            {
                c = 32;
            }
            else if (color == ConsoleColor.Blue)
            {
                c = 34;
            }
            else
            {
                c = 37;
            }

            return string.Format("\u001b[{0}m{{0}}\u001b[0m", c);
            // return "{0}";
        }
    }
}