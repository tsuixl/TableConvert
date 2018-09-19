using System;

namespace ConvertCmd.Core.Util
{
    public static class SystemUtil
    {
        public static ArgsData Content;

        public static void Abend (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Error);
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
            KillApp (info);
        }


        public static void Log (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Info);
            Console.WriteLine(info);
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
                Console.WriteLine(info);
            }
            else
            {
                Console.WriteLine(string.Format("{0}{1}", GetSpacing(spacing), info));
            }
        }


        public static void Wran (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Warn);
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Print(ConvertExceptionInfo info)
        {
            Console.ForegroundColor = GetColor(info.InfoType);
            Console.WriteLine(info.Info);
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
                info = string.Format(@"\e[#{{{0}}}m#{{{1}}}\e[0m", 31, info);
            }
            
            throw new System.Exception (info);
        }


        public static void Log (string info, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(info);
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
    }
}