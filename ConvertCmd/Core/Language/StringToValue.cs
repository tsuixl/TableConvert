using System.Text;

namespace ConvertCmd.Core.Language
{
    public static class StringToValue
    {
        private static StringBuilder _tempBuilder;

        static StringToValue ()
        {
            _tempBuilder = new StringBuilder (32);
        }

        public static long? ToNumber (string str, long? defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                goto DEFAULT_VALUE;
            }

            long v ;
            if (long.TryParse(str, out v))
            {
                return v;
            }
            goto DEFAULT_VALUE;
            
DEFAULT_VALUE:
            if (defaultValue != null && defaultValue.HasValue)
            {
                return defaultValue;
            }
            return null;
        } 

        public static float? ToFloat (string str, float? defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                goto DEFAULT_VALUE;
            }

            float v ;
            if (float.TryParse(str, out v))
            {
                return v;
            }
            goto DEFAULT_VALUE;
            
DEFAULT_VALUE:
            if (defaultValue != null && defaultValue.HasValue)
            {
                return defaultValue;
            }
            return null;
        } 


        public static double? ToDouble (string str, double? defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                goto DEFAULT_VALUE;
            }

            double v ;
            if (double.TryParse(str, out v))
            {
                return v;
            }
            goto DEFAULT_VALUE;
            
DEFAULT_VALUE:
            if (defaultValue != null && defaultValue.HasValue)
            {
                return defaultValue;
            }
            return null;
        } 


        public static bool? ToBool (string str, bool? defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                goto DEFAULT_VALUE;
            }

            bool v ;
            if (bool.TryParse(str, out v))
            {
                return v;
            }
            goto DEFAULT_VALUE;
            
DEFAULT_VALUE:
            if (defaultValue != null && defaultValue.HasValue)
            {
                return defaultValue;
            }
            return null;
        } 


        public static string ToString (string str, string defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }
            
            return str;
        }


        public static string GetLevel (int level)
        {
            _tempBuilder.Length = 0;
            for (int i = 0; i < level; i++)
            {
                _tempBuilder.Append("\t");
            }
            return _tempBuilder.ToString();
        }
    }
}