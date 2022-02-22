using GameOfLife.Extensions;
using GameOfLife.Logic;
using GameOfLife.UI.Menus;

namespace GameOfLife.UI.Screens;

public class GameScreen
{
    public int WorldViewOffsetX { get; set; }
    public int WorldViewOffsetY { get; set; }

    private readonly int _worldViewWidth;
    private readonly int _worldViewHeigth;
    private readonly GameMenu _gameMenu;

    public GameScreen()
    {
        _worldViewWidth = Engine.GetInstance().Settings.WorldViewWidth;
        _worldViewHeigth = Engine.GetInstance().Settings.WorldViewHeigth;
        _gameMenu = new GameMenu(this);
    }

    public void Render()
    {
        Console.Clear();
        RenderStats();
        RenderWorld();
        RenderMenu();
    }

    public void RenderWithoutMenu()
    {
        Console.Clear();
        RenderStats();
        RenderWorld();
    }

    private void RenderStats()
    {
        RenderInfoTopBorder();
        Console.Write($"│ Size: {Engine.GetInstance().World.Stats.Width}x{Engine.GetInstance().World.Stats.Heigth} ");
        Console.Write($"│ Cells: {Engine.GetInstance().World.Stats.CellsAlive}/{Engine.GetInstance().World.Stats.CellsDead} [{Engine.GetInstance().World.Stats.PercentAlive}% {GetPercentAliveBar()}] ");
        Console.Write($"│ View: ↔{WorldViewOffsetX}:{WorldViewOffsetX + _worldViewWidth} ↕{WorldViewOffsetY}:{WorldViewOffsetY + _worldViewHeigth} ");
        Console.Write($"│ Generation: {Engine.GetInstance().World.Stats.Generation} │{Environment.NewLine}");
        RenderInfoBottomBorder();
    }

    private string GetPercentAliveBar()
    {
        int rounded = Engine.GetInstance().World.Stats.PercentAlive / 10;
        return ($"{"█".Repeat(rounded)}{"░".Repeat(10 - rounded)}");
    }

    private void RenderInfoTopBorder()
    {
        Console.WriteLine($"┌" +
            $"{"─".Repeat(9 + Engine.GetInstance().World.Stats.Width.ToString().Length + Engine.GetInstance().World.Stats.Heigth.ToString().Length)}" +
            $"┬" +
            $"{"─".Repeat(25 + Engine.GetInstance().World.Stats.CellsAlive.ToString().Length + Engine.GetInstance().World.Stats.CellsDead.ToString().Length + Engine.GetInstance().World.Stats.PercentAlive.ToString().Length)}" +
            $"┬" +
            $"{"─".Repeat(13 + WorldViewOffsetX.ToString().Length + (WorldViewOffsetX + _worldViewWidth).ToString().Length + WorldViewOffsetY.ToString().Length + (WorldViewOffsetX + _worldViewWidth).ToString().Length)}" +
            $"┬" +
            $"{"─".Repeat(14 + Engine.GetInstance().World.Stats.Generation.ToString().Length)}" +
            $"┐");
    }
    private void RenderInfoBottomBorder()
    {
        Console.WriteLine($"└" +
            $"{"─".Repeat(9 + Engine.GetInstance().World.Stats.Width.ToString().Length + Engine.GetInstance().World.Stats.Heigth.ToString().Length)}" +
            $"┴" +
            $"{"─".Repeat(25 + Engine.GetInstance().World.Stats.CellsAlive.ToString().Length + Engine.GetInstance().World.Stats.CellsDead.ToString().Length + Engine.GetInstance().World.Stats.PercentAlive.ToString().Length)}" +
            $"┴" +
            $"{"─".Repeat(13 + WorldViewOffsetX.ToString().Length + (WorldViewOffsetX + _worldViewWidth).ToString().Length + WorldViewOffsetY.ToString().Length + (WorldViewOffsetX + _worldViewWidth).ToString().Length)}" +
            $"┴" +
            $"{"─".Repeat(14 + Engine.GetInstance().World.Stats.Generation.ToString().Length)}" +
            $"┘");
    }

    private void RenderWorld()
    {
        Console.Write("┌");
        for (int i = 0; i < _worldViewWidth * 2; i++)
        {
            Console.Write("─");
        }
        Console.Write($"┐{Environment.NewLine}");

        for (int y = 0; y < _worldViewHeigth; y++)
        {
            Console.Write("│");
            for (int x = 0; x < _worldViewWidth; x++)
            {
                if (PointNotInMatrix(y + WorldViewOffsetY, x + WorldViewOffsetX))
                {
                    Console.Write("><");
                    continue;
                }

                if (Engine.GetInstance().World.Matrix[y + WorldViewOffsetY, x + WorldViewOffsetX])
                {
                    Console.Write("██");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.Write($"│{Environment.NewLine}");
        }
        Console.Write("└");
        for (int i = 0; i < _worldViewWidth * 2; i++)
        {
            Console.Write("─");
        }
        Console.Write($"┘{Environment.NewLine}");
    }

    private bool PointNotInMatrix(int x, int y)
        => y > Engine.GetInstance().World.Matrix.GetLength(0) - 1 || x > Engine.GetInstance().World.Matrix.GetLength(1) - 1 || x < 0 || y < 0;

    private void RenderMenu()
    {
        _gameMenu.Render();
        _gameMenu.Activate(Console.ReadKey().KeyChar);
    }


}
