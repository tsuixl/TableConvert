using System;

namespace ConvertCmd.Core.Util
{
    public static class SystemUtil
    {
        public static void Abend (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Error);
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }


        public static void Log (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Info);
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Wran (string info)
        {
            Console.ForegroundColor = GetColor(ExceptionInfoType.Warn);
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Print (ConvertExceptionInfo info)
        {
            Console.ForegroundColor = GetColor(info.InfoType);
            Console.WriteLine(info.Info);
            Console.ForegroundColor = ConsoleColor.White;
            if (info.InfoType == ExceptionInfoType.Error)
                Environment.Exit(0);
        }


        public static void Log (string info, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
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