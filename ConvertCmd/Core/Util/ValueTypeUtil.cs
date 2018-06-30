using ConvertCmd.Core.Enum;
using System.Collections.Generic;

namespace ConvertCmd.Core.Util
{
    public static class ValueTypeUtil
    {
        private static Dictionary<ValueType, List<string>> _valueTypeStr ;

        static ValueTypeUtil ()
        {
            _valueTypeStr = new Dictionary<ValueType, List<string>>();
            _valueTypeStr.Add (ValueType.Array, new List<string>() { "array" });
            _valueTypeStr.Add (ValueType.Float, new List<string>() { "float" });
            _valueTypeStr.Add (ValueType.Double, new List<string>() { "double" });
            _valueTypeStr.Add (ValueType.Integer, new List<string>() { "int", "long" });
            _valueTypeStr.Add (ValueType.Json, new List<string>() { "json" });
            _valueTypeStr.Add (ValueType.Map, new List<string>() { "map" });
            _valueTypeStr.Add (ValueType.None, new List<string>() { "none" });
            _valueTypeStr.Add (ValueType.String, new List<string>() { "string" });
            _valueTypeStr.Add (ValueType.Bool, new List<string>() { "bool", "boolean" });
        }

        public static ValueType String2ValueType (string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return ValueType.None;
            str = str.ToLower();
            foreach (var item in _valueTypeStr)
            {
                if(item.Value.Contains(str))
                    return item.Key;
            }
            // SystemUtil.Abend (string.Format("未知类型[{0}]", str));
            return ValueType.None;
        }
    }
}