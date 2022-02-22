using GameOfLife.Configuration;
using GameOfLife.Logic.Worlds;
using GameOfLife.UI.Screens;

namespace GameOfLife.Logic;

public class Engine
{
    private static object locker = new object();
    private static Engine instance;

    public Settings Settings { get; private set; }
    public World World { get; private set; }
    public bool Pause { get; private set; }
    public int GameSpeed { get; private set; }

    private Engine()
    {
        Settings = new Settings();
        Settings.Load();
        World = new World(Settings.WorldWidth, Settings.WorldHeigth);
        GameSpeed = 1;
        Pause = false;
    }

    public static Engine GetInstance()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
            }
        }
        return instance;
    }

    public void Run()
    {
        new MainMenuScreen().Render();
    }   

    internal void GenerateNewWorld()
    {
        World = new World(Settings.WorldWidth, Settings.WorldHeigth);
    }
}
