using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ExamBasicOfCSharp;

[JsonConverter(typeof(StringEnumConverter))]
public enum LanguageTypes
{
    [EnumMember(Value = "0")]
    None,
    [EnumMember(Value = "1")]
    Russian,
    [EnumMember(Value = "2")]
    English,
    [EnumMember(Value = "3")]
    German,
    //....
}
