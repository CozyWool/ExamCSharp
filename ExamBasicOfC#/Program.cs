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



while (true)
{
    Console.WriteLine("\n\tПрограмма \"Словарь\"\n");
    Console.WriteLine("1 - Создать словарь");
    Console.WriteLine("2 - Добавить слово/перевод в словарь");
    Console.WriteLine("3 - Заменить слово/перевод в словаре");
    Console.WriteLine("4 - Найти слово/перевод в словаре");
    Console.WriteLine("5 - Сохранить словарь в файл");
    Console.WriteLine("6 - Удалить словарь и его файл");
    Console.WriteLine("7 - Экспортировать слово/перевод в отдельный файл");
    Console.WriteLine("0 - Выйти");
    Console.Write("\nВведите ответ: ");
    var t = MenuTypesHelper.Parse(Console.ReadLine());
    Console.Clear();
    
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
        case MenuTypes.Delete:
            Delete();
            break;
        case MenuTypes.ExportWord:
            ExportWord();
            break;
        case MenuTypes.Exit:
            StopProgram();
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
    throw new NotImplementedException();
}

void Find()
{
    throw new NotImplementedException();
}

void Replace()
{
    throw new NotImplementedException();
}

void Add()
{
    throw new NotImplementedException();
}

void CreateDictionary()
{
    throw new NotImplementedException();
}

void StopProgram()
{
    Console.Clear();
    Console.WriteLine("\n\t\tДо свидания!\n");
    Console.ReadKey();
}