namespace ConvertCmd.Core
{
    public enum ExceptionInfoType
    {
        Info,
        Warn,
        Error,
    }


    public class ConvertExceptionInfo
    {
        public bool Abend {get; internal set;}

        public string Info {get; internal set;}

        public ExceptionInfoType InfoType {get; internal set;}

        public static ConvertExceptionInfo Create (bool abend, ExceptionInfoType infoType, string info = "")
        {
            ConvertExceptionInfo exceptionInfo = new ConvertExceptionInfo();
            exceptionInfo.Abend = abend;
            exceptionInfo.Info = info;
            if (exceptionInfo.Abend)
                exceptionInfo.InfoType = ExceptionInfoType.Error;
            else
                exceptionInfo.InfoType = infoType;

            return exceptionInfo;
        }


        public static ConvertExceptionInfo Log (string info)
        {
            ConvertExceptionInfo exceptionInfo = new ConvertExceptionInfo();
            exceptionInfo.Abend = false;
            exceptionInfo.Info = info;
            exceptionInfo.InfoType = ExceptionInfoType.Info;
            return exceptionInfo;
        }

        public static ConvertExceptionInfo Warn (string info)
        {
            ConvertExceptionInfo exceptionInfo = new ConvertExceptionInfo();
            exceptionInfo.Abend = false;
            exceptionInfo.Info = info;
            exceptionInfo.InfoType = ExceptionInfoType.Warn;
            return exceptionInfo;
        }

        public static ConvertExceptionInfo Error (string info)
        {
            ConvertExceptionInfo exceptionInfo = new ConvertExceptionInfo();
            exceptionInfo.Abend = true;
            exceptionInfo.Info = info;
            exceptionInfo.InfoType = ExceptionInfoType.Error;
            return exceptionInfo;
        }
    }
}