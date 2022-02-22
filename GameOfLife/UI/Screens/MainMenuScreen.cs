using GameOfLife.Logic;
using GameOfLife.Menu;

namespace GameOfLife.UI.Screens;

internal class MainMenuScreen
{

    public MainMenuScreen()
    {
    }
    public void Render()
    {
        Console.Clear();
        Console.WriteLine("   _|_|_|                                                        _|_|      _|        _|      _|_|            ");
        Console.WriteLine(" _|          _|_|_|  _|_|_|  _|_|      _|_|          _|_|      _|          _|              _|        _|_|    ");
        Console.WriteLine(" _|  _|_|  _|    _|  _|    _|    _|  _|_|_|_|      _|    _|  _|_|_|_|      _|        _|  _|_|_|_|  _|_|_|_|  ");
        Console.WriteLine(" _|    _|  _|    _|  _|    _|    _|  _|            _|    _|    _|          _|        _|    _|      _|        ");
        Console.WriteLine("   _|_|_|    _|_|_|  _|    _|    _|    _|_|_|        _|_|      _|          _|_|_|_|  _|    _|        _|_|_|  ");
        Console.WriteLine("┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");
        Console.WriteLine($"├World: ↔{Engine.GetInstance().World.Stats.Width} ↕{Engine.GetInstance().World.Stats.Heigth} ■{Engine.GetInstance().World.Stats.CellsAlive} X{Engine.GetInstance().World.Stats.CellsDead}{GetWorldInfoSpaceFillString()}");
        Console.WriteLine($"├─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─┼─by Radosław Król┤");
        Console.WriteLine("└─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘");

        var mainMenu = new MainMenu();
        mainMenu.Render();
        mainMenu.Activate(Console.ReadKey().KeyChar);
    }

    private string GetWorldInfoSpaceFillString()
    {
        string worldInfoSpaceFill = "";
        bool cross = false;
        for (int i = 0; i < CalculateWorldInfoStringLength(); i++)
        {
            if (cross)
            {
                worldInfoSpaceFill += "┼";
                cross = false;
            }
            else
            {
                worldInfoSpaceFill += "─";
                cross = true;
            }
        }

        worldInfoSpaceFill += "┤";

        return worldInfoSpaceFill;
    }

    private int CalculateWorldInfoStringLength() 
        => 93 - (Engine.GetInstance().World.Stats.Width.ToString().Length + Engine.GetInstance().World.Stats.Heigth.ToString().Length + Engine.GetInstance().World.Stats.CellsAlive.ToString().Length + Engine.GetInstance().World.Stats.CellsDead.ToString().Length);
}
