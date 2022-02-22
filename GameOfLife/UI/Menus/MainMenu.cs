using GameOfLife.Logic;
using GameOfLife.UI.Menus;
using GameOfLife.UI.Screens;

namespace GameOfLife.Menu;

public class MainMenu : IMenu
{
    public IEnumerable<MenuOption> Options { get; private set; }

    private int buttonWidth = 40;
    private int menuWidth = 146;
    public MainMenu()
    {
        Options = new List<MenuOption>() {
            new MenuOption("s","Start"),
            new MenuOption("g","Generate new world"),
            new MenuOption("i","Import world WIP"),
            new MenuOption("d","Download world WIP"),
            new MenuOption("o","Options WIP"),
            new MenuOption("e","Exit"),
        };
    }

    public void Render()
    {
        string topButtonBorder = "";
        string bottomButtonBorder = "";
        for (int i = 0; i < buttonWidth - 2; i++)
        {
            topButtonBorder += "─";
            bottomButtonBorder += "═";
        }

        string spaceBeforeButton = "";
        for (int i = 0; i < (menuWidth-(buttonWidth*2))/2; i++)
        {
            spaceBeforeButton += " ";
        }

        foreach (var option in Options)
        {
            string spaceInsideButton = "";
            for (int i = 0; i < buttonWidth - (6 + option.Label.Length); i++)
            {
                spaceInsideButton += " ";
            }
            Console.WriteLine($"{spaceBeforeButton}┌{topButtonBorder}┐");
            Console.WriteLine($"{spaceBeforeButton}│[{option.Key}] {option.Label}{spaceInsideButton}║");
            Console.WriteLine($"{spaceBeforeButton}└{bottomButtonBorder}╝");
        }
    }

    public void Activate(char key)
    {
        switch (key)
        {
            case 's': StartNewGame(); break;
            case 'g': GenerateNewWorld(); break;
            case 'i': ImportWorld(); break;
            case 'd': DownloadWorld(); break;
            case 'o': OpenSettings(); break;
            case 'e': Exit(); break;
        }
    }

    private void StartNewGame()
    {
        var gameScreen = new GameScreen();
        gameScreen.Render();

    }
    private void GenerateNewWorld()
    {
        Engine.GetInstance().GenerateNewWorld();   
        new MainMenuScreen().Render();
    }

    private void ImportWorld()
    {
        throw new NotImplementedException();
    }

    private void DownloadWorld()
    {
        throw new NotImplementedException();
    }

    private void OpenSettings()
    {
        throw new NotImplementedException();
    }

    private void Exit()
    {
        Environment.Exit(0);
    }    

}
