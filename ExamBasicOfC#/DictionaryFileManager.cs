using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ExamBasicOfCSharp;

public class DictionaryFileManager
{
    public string Path { get; }
    public DictionaryFileManager(string path)
    {
        Path = path;
    }
    public DictionaryFileManager() : this("dict.json") { }

    public void Save(LanguageDictionary langDict)
    {
        var json = JsonConvert.SerializeObject(langDict, Formatting.Indented, new StringEnumConverter());
        using var sw = new StreamWriter(Path);
        sw.WriteLine(json);
    }
    public LanguageDictionary Load() 
    {
        // TODO: Адаптировать под список словарей(чтобы было чтение из разных файлов), сделать отдельную папку со словарями
        using var sr = new StreamReader(Path);
        var json = sr.ReadToEnd();
        var deserialized = JsonConvert.DeserializeObject<LanguageDictionary>(json);
        return deserialized;
    }

    public static void ExportWordToFile(DictionaryPart dictPart, string path)
    {
        using var sw = new StreamWriter(path);
        var json = JsonConvert.SerializeObject(dictPart, Formatting.Indented, new StringEnumConverter());
        sw.WriteLine(json);
    }
}
