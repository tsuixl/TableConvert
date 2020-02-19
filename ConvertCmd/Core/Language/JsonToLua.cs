using System.Text;
using ConvertCmd.Core.Enum;
using ConvertCmd.Core.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConvertCmd.Core.Language
{
    public class JsonToLua
    {
        private StringBuilder _txtBuilder;

        public JsonToLua ()
        {
            _txtBuilder = new StringBuilder(32);
        }

        public void ResetCache ()
        {
            _txtBuilder.Length = 0;
        }


        public string ConvertString(string fieldName, string fieldValue, ValueType fieldType, int level, string mainKey)
        {
            _txtBuilder.Length = 0;
            if (fieldType == ValueType.Array || 
                fieldType == ValueType.Map ||
                fieldType == ValueType.Json)
            {
                if (string.IsNullOrEmpty(fieldValue))
                {
                    // string.Format("{0}{1} = {2}", levelStr, key, value);
                    return JsonConvertString(fieldName, null, level);
                }
                else
                {
                    try
                    {
                        var token = JToken.Parse (fieldValue);
                    }
                    catch (System.Exception)
                    {
                        SystemUtil.Abend (string.Format("Key {2} 字段 {0} Value {1} Json解析失败!", fieldName, fieldValue, mainKey));
                    }
                }
                
                return JsonConvertString(fieldName, JToken.Parse(fieldValue), level);
            }
            else if (fieldType == ValueType.Float)
            {
                return ConvertFloat (fieldName, fieldValue, level);
            }
            else if (fieldType == ValueType.Double)
            {
                return ConvertDouble (fieldName, fieldValue, level);
            }
            else if (fieldType == ValueType.Integer)
            {
                return ConvertDouble(fieldName, fieldValue, level);
            }
            else if (fieldType == ValueType.String)
            {
                return ConvertString(fieldName, fieldValue, level);
            }
            else if (fieldType == ValueType.Bool)
            {
                return ConvertBool(fieldName, fieldValue, level);
            }
            else
            {
                return string.Empty;
            }
        }

        public string JsonConvertString (string key, JToken token, int level)
        {
            if (IsNumber(key))
                key = string.Format("[{0}]", key);

            var levelStr = StringToValue.GetLevel(level);

            if (token == null)
            {
                return string.Format("{0}{1} = {{}}", levelStr, key);
            }
            else if (token.Type == JTokenType.Property)
            {
                JProperty property = token as JProperty;
                JsonConvertString(property.Name, property.Value, level + 1);
            }
            else if (token.Type == JTokenType.Array)
            {
                JArray array = JArray.Parse(token.ToString());
                _txtBuilder.AppendLine(string.Format("{0}{1} = {{", levelStr, key));
                for (int i = 0; i < array.Count; i++)
                {
                    var item = array[i];
                    JsonConvertString ((i + 1).ToString(), item, level + 1);
                    if (i < array.Count - 1)
                        _txtBuilder.AppendLine(",");
                }
                _txtBuilder.AppendFormat("\n{0}}}", levelStr);
            }
            else if (token.Type == JTokenType.Object)
            {
                JObject obj = token as JObject;
                _txtBuilder.AppendLine(string.Format("{0}{1} = {{", levelStr, key));
                int index = 0;
                foreach (var item in obj)
                {
                    JsonConvertString(item.Key, item.Value, level + 1);
                    if (index < obj.Count - 1)
                        _txtBuilder.Append(",\n");
                    ++index;
                }
                _txtBuilder.AppendFormat("\n{0}}}", levelStr);
            }
            else if (token.Type == JTokenType.Integer)
            {
                _txtBuilder.Append(ConvertInteger(key, token.ToString(), level));
            }
            else if (token.Type == JTokenType.String)
            {
                _txtBuilder.Append(ConvertString(key, token.ToString(), level));
            }
            else if (token.Type == JTokenType.Float)
            {
                _txtBuilder.Append(ConvertDouble(key, token.ToString(), level));
            }
            else if (token.Type == JTokenType.Boolean)
            {
                _txtBuilder.Append(ConvertBool(key, token.ToString(), level));
            }
            else
            {
                SystemUtil.Abend(string.Format("该类型不被支持 [{0}] !", token.Type));
            }
            ++level;
            return _txtBuilder.ToString();
        } 


        public bool IsNumber (string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            long v;
            return long.TryParse(str, out v);
        }


        public static string ConvertInteger (string key, string jsonString, int level)
        {
            var levelStr = StringToValue.GetLevel(level);
            var value = StringToValue.ToNumber (jsonString, 0);
            if (value != null)
            {
                return string.Format("{0}{1} = {2}", levelStr, key, value);
            }
            else
            {
                return string.Format("{0}{1} = 0", levelStr, key);
            }
        }

        public static string ConvertFloat (string key, string jsonString, int level)
        {
            var levelStr = StringToValue.GetLevel(level);
            var value = StringToValue.ToFloat (jsonString, 0);
            if (value != null)
            {
                return string.Format("{0}{1} = {2}", levelStr, key, value);
            }
            else
            {
                return string.Format("{0}{1} = 0", levelStr, key);
            }
        }


        public static string ConvertDouble (string key, string jsonString, int level)
        {
            var levelStr = StringToValue.GetLevel(level);
            var value = StringToValue.ToDouble (jsonString, 0);
            if (value != null)
            {
                return string.Format("{0}{1} = {2}", levelStr, key, value);
            }
            else
            {
                return string.Format("{0}{1} = 0", levelStr, key);
            }
        }


        public static string ConvertBool (string key, string jsonString, int level)
        {
            var levelStr = StringToValue.GetLevel(level);
            var value = StringToValue.ToBool (jsonString, false);
            var str = (value != null && value.Value) ? "true" : "false";
            if (value != null)
            {
                return string.Format("{0}{1} = {2}", levelStr, key, str);
            }
            else
            {
                return string.Format("{0}{1} = false", levelStr, key);
            }
        }


        public static string ConvertString (string key, string jsonString, int level)
        {
            var levelStr = StringToValue.GetLevel(level);
            var value = StringToValue.ToString (jsonString, "");
            if (value != null)
            {
                value = value.Replace("\n", "\\n").Replace("\"", "\\\"");
                return string.Format("{0}{1} = \"{2}\"", levelStr, key, value);
            }
            else
            {
                return string.Format("{0}{1} = \"\"", levelStr, key);
            }
        }


    }
}