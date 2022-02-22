namespace GameOfLife.UI.Menus;

public interface IMenu
{
    IEnumerable<MenuOption> Options { get; }

    void Activate(char key);
    void Render();
}
