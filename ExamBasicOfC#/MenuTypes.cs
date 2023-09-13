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
    Load,
    Delete,
    ExportWord,
    Show
}

public static class MenuTypesHelper
{
    public static MenuTypes Parse(string value)
    {
        return Enum.Parse<MenuTypes>(value);
    }
}
