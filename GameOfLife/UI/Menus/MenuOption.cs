namespace GameOfLife.UI.Menus;

public class MenuOption
{
    public string Key { get; private set; }
    public string Label { get; private set; }
    public bool Active { get; set; }

    public MenuOption(string key, string label)
    {
        Key = key;
        Label = label;
        Active = true;
    }
    public MenuOption(string key, string label, bool active)
    {
        Key = key;
        Label = label;
        Active = active;
    }
}
