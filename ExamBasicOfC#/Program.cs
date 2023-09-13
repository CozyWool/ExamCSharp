using ExamBasicOfCSharp;
using System.Xml.Linq;

//var langDict = new LanguageDictionary(new()
//{
//    new("Hello", new(){"Привет","Здравствуйте"},Language.English,Language.Russian),
//}, Language.English, Language.Russian);
//Console.WriteLine(langDict.ToString());

//langDict.AddWord(new("Bye", new() { "Пока", "До свидания" }, Language.English, Language.Russian));
//Console.WriteLine(langDict.ToString());

////langDict.ReplaceTranslation("Hello", "Привет", "Здарова");
////Console.WriteLine(langDict.ToString());

//langDict.ReplaceWord("Bye", "Goodbye");
//Console.WriteLine(langDict.ToString());

//langDict.RemoveTranslation("Hello", "Здарова");
//Console.WriteLine(langDict.ToString());

////langDict.RemoveWord("Goodbye");
////Console.WriteLine(langDict.ToString());

//var fileManager = new DictionaryFileManager();
//fileManager.Save(langDict);

//LanguageDictionary languageDictionary = fileManager.Load();
//Console.WriteLine("Десериализация");
//Console.WriteLine(languageDictionary.ToString());

LanguageDictionary CurrentDictionary = new();
DictionaryFileManager dictionaryFileManager = new();

while (true)
{
    Console.WriteLine("\n\tПрограмма \"Словарь\"\n");
    Console.WriteLine("1 - Создать словарь");
    Console.WriteLine("2 - Добавить слово/перевод в словарь");
    Console.WriteLine("3 - Заменить слово/перевод в словаре");
    Console.WriteLine("4 - Найти слово/перевод в словаре");
    Console.WriteLine("5 - Сохранить словарь в файл");
    Console.WriteLine("6 - Открыть словарь из файла");
    Console.WriteLine("7 - Удалить словарь и его файл");
    Console.WriteLine("8 - Экспортировать слово/перевод в отдельный файл");
    Console.WriteLine("9 - Посмотреть текущий словарь");
    Console.WriteLine("0 - Выйти");
    Console.Write("\nВведите ответ: ");
    var t = MenuTypesHelper.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine($"\tТекущий словарь: {CurrentDictionary}\n");

    switch (t)
    {
        case MenuTypes.CreateDictionary:
            CreateDictionary();
            break;
        case MenuTypes.Add:
            Add();
            break;
        case MenuTypes.Replace:
            Replace();
            break;
        case MenuTypes.Find:
            Find();
            break;
        case MenuTypes.Save:
            Save();
            break;
        case MenuTypes.Load:
            Load();
            break;
        case MenuTypes.Delete:
            Delete();
            break;
        case MenuTypes.ExportWord:
            ExportWord();
            break;
        case MenuTypes.Exit:
            StopProgram();
            break;
        case MenuTypes.Show:
            // оно и так показывается
            break;
        default:
            break;
    }
}

void Load()
{
    Console.WriteLine("\tСписок словарей");
    dictionaryFileManager.ShowDictionaries("Dictionaries");
    int fileCount = dictionaryFileManager.Files.Count;
    
    int answer = 0;
    while (answer < 1 && answer > fileCount)
    {
        try 
        {
            Console.WriteLine("Ваш выбор: ");
            answer = int.Parse(Console.ReadLine());
        }
        catch { Console.WriteLine("Произошла ошибка при вводе, попробуйте еще раз."); }
    }
    dictionaryFileManager.Load(answer);
}

void CreateDictionary()
{
    // TODO: сделать предупреждение о потере несохранненых данных
    string[] typesArray = Enum.GetNames<LanguageTypes>();
    for (int i = 1; i < typesArray.Length; i++)
    {
        string type = typesArray[i];
        Console.WriteLine($"{i} - {type}");
    }
    Console.Write("Введите с какого языка вы хотите переводить): ");
    LanguageTypes fromLanguage = Enum.Parse<LanguageTypes>(Console.ReadLine());
    Console.Write("Введите на какой языка вы хотите переводить): ");
    LanguageTypes toLanguage = Enum.Parse<LanguageTypes>(Console.ReadLine());
    CurrentDictionary = new LanguageDictionary(fromLanguage, toLanguage);
    Console.WriteLine($"\tСловарь создан {CurrentDictionary}");
    Console.Write("Сохранить?(Y/N): ");
    if (Console.ReadLine().ToUpper() == "Y") Save();
}
void Add()
{
    Console.Write($"Введите слово на {CurrentDictionary.FromLanguage}: ");
    string word = Console.ReadLine();
    Console.Write($"Введите перевод(-ы) на {CurrentDictionary.ToLanguage} через ПРОБЕЛ: ");
    List<string> translation = Console.ReadLine().Split().ToList();
    CurrentDictionary.AddWord(new DictionaryPart(word, translation, CurrentDictionary.FromLanguage, CurrentDictionary.ToLanguage));
}
void Replace()
{
    Console.WriteLine("1 - Заменить слово");
    Console.WriteLine("2 - Заменить перевод");
    Console.Write("Что вы хотите заменить?:");
    int answer = 0;
    while (answer < 1 && answer > 2)
    {
        try
        {
            Console.WriteLine("Ваш выбор: ");
            answer = int.Parse(Console.ReadLine());
        }
        catch { Console.WriteLine("Произошла ошибка при вводе, попробуйте еще раз."); }
    }
    switch (answer)
    {
        case 1:
            Console.Write("Введите старое слово: ");
            string oldWord = Console.ReadLine().Trim();
            Console.Write("Введите новое слово: ");
            string newWord = Console.ReadLine().Trim();
            CurrentDictionary.ReplaceWord(oldWord, newWord);
            break;
        case 2:
            Console.Write($"Введите старый перевод слова: ");
            string oldTranslation = Console.ReadLine().Trim();
            Console.Write($"Введите новый перевод слова: ");
            string newTranslation = Console.ReadLine().Trim();
            CurrentDictionary.ReplaceTranslation(oldTranslation, newTranslation);
            break;

        default:
            break;
    }
}
void ExportWord()
{
    throw new NotImplementedException();
}

void Delete()
{
    throw new NotImplementedException();
}

void Save()
{
    if (dictionaryFileManager.SaveDictionary(CurrentDictionary, out var savePath))
        Console.WriteLine($"Файл сохранен в папку программы под названием: {savePath}.");
    else
        Console.WriteLine($"Произошла ошибка при сохранении файла.");
}

void Find()
{
    throw new NotImplementedException();
}




void StopProgram()
{
    Console.Clear();
    Console.WriteLine("\n\t\tДо свидания!\n");
    Console.ReadKey();
}