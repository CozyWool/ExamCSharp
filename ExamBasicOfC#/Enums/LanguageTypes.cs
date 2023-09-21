using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ExamBasicOfCSharp.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum LanguageTypes
{
    None,
    Russian,
    English,
    German,
    //....
}
