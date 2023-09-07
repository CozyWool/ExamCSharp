namespace ExamBasicOfCSharp;

public enum MenuTypes
{
    None = -1,
    Exit,
    CreateDictionary,
    Add,
    Replace,
    Find,
    Save,
    Delete,
    ExportWord,
    
}

public static class MenuTypesHelper
{
    public static MenuTypes Parse(string value)
    {
        return Enum.Parse<MenuTypes>(value);
    }
}
