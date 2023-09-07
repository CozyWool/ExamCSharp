using Newtonsoft.Json;
using System.Text;

namespace ExamBasicOfCSharp;

public enum Language
{
    None,
    Russian,
    English,
    German,
    //....
}

public class LanguageDictionary
{
    [JsonProperty("Dictionary")]
    private readonly List<DictionaryPart> dictionary;
    
    public Language FromLanguage { get; }
    public Language ToLanguage { get; }

    public List<DictionaryPart> GetDictionary() => dictionary;

    public LanguageDictionary(List<DictionaryPart>? dictionary, Language fromLanguage, Language toLanguage)
    {
        FromLanguage = fromLanguage;
        ToLanguage = toLanguage;
        this.dictionary = dictionary ?? new List<DictionaryPart>();
    }

    public void AddWord(DictionaryPart value)
    {
        if (value.FromLanguage != FromLanguage && value.ToLanguage != ToLanguage)
            throw new Exception($"Слово {value} не может быть добавлено в словарь из-за несоотвествия языков!");

        if (dictionary.Contains(value))
            dictionary.Find(dictPart => dictPart.Word == value.Word)
                      .AddTranslation(value.Translation);
        else
            dictionary.Add(value);
    }
    public void RemoveWord(string word)
    {
        if (FindWord(word, out DictionaryPart dictPart) && dictionary.Remove(dictPart))
            return;
        else
            throw new Exception($"Ошибка в удалении слова {word}!");
    }
    public void RemoveTranslation(string word, string translation)
    {
        if (FindWord(word, out DictionaryPart dictPart))
            dictPart.RemoveTranslation(translation);
        else
            throw new Exception($"Ошибка в удалении перевода {translation} в слове {word}!");
    }

    /// <summary>
    /// True if word found, otherwise false
    /// </summary>
    /// <param name="word">Искомое слово</param>
    /// <param name="result">Результат поиска</param>
    public bool FindWord(string word, out DictionaryPart result)
    {
        result = dictionary.Find(dictPart => dictPart.Word == word);
        return result != null;
    }
    public void ReplaceWord(string oldWord, string newWord)
    {
        if(FindWord(oldWord, out DictionaryPart dictPart))
            dictPart.Word = newWord;
    }
    public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
    {
        foreach (DictionaryPart dictPart in dictionary.Where(dictPart => dictPart.Word == word))
        {
            for (int i = 0; i < dictPart.Translation.Count; i++)
            {
                if (dictPart.Translation[i] == oldTranslation)
                    dictPart.Translation[i] = newTranslation;
            }
        }
    }
    public List<string> this[string word]
    {
        get
        {
            return dictionary.Where(dictPart => dictPart.Word == word)
                             .SelectMany(dictPart => dictPart.Translation)
                             .ToList();
        }
    }
    public override string? ToString()
    {
        StringBuilder sb = new($"\n\t{FromLanguage}-{ToLanguage} словарь\n");
        foreach (var dictionaryPart in dictionary)
        {
            sb.AppendLine(dictionaryPart.ToString());
        }
        return sb.ToString();
    }
}
