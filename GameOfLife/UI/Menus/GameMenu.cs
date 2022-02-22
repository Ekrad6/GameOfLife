using GameOfLife.Logic;
using GameOfLife.UI.Screens;

namespace GameOfLife.UI.Menus
{
    internal class GameMenu : IMenu
    {
        public IEnumerable<MenuOption> Options { get; private set; }

        private GameScreen _gameScreen;
        private MenuOption _prevGenerationButton;

        public GameMenu(GameScreen gameScreen)
        {
            _gameScreen = gameScreen;
            _prevGenerationButton = new MenuOption(",", "Prev generation", false);

            Options = new List<MenuOption>() {
                new MenuOption("p","Auto Play"),
                new MenuOption("wasd","Move view"),
                new MenuOption("WASD","Move view by 50"),
                _prevGenerationButton,
                new MenuOption(".","Next generation"),
                new MenuOption(">","Skip 50 generation"),
                new MenuOption("n","New world"),
                new MenuOption("e","Exit to main menu"),
            };

        }
        public void Activate(char key)
        {
            switch (key)
            {
                case 'p': AutoPlay(); break;
                case 'w': MoveViewUp(); break;
                case 's': MoveViewDown(); break;
                case 'a': MoveViewLeft(); break;
                case 'd': MoveViewRight(); break;
                case 'W': MoveViewUp(50); break;
                case 'S': MoveViewDown(50); break;
                case 'A': MoveViewLeft(50); break;
                case 'D': MoveViewRight(50); break;
                case ',': PrevGeneration(); break;
                case '.': NextGeneration(); break;
                case '>': SkipGenerations(); break;
                case 'n': NewWorld(); break;
                case 'e': GoToMainMenu(); break;
            }
        }
        public void Render()
        {
            Console.Write($"│");
            foreach (var option in Options)
            {
                if (option.Active)
                {
                    Console.Write($" [{option.Key}] {option.Label} │");
                }

            }
        }

        private void AutoPlay()
        {
            while (Engine.GetInstance().World.Stats.CellsAlive > 0)
            {
                Engine.GetInstance().World.NextGeneration();
                _gameScreen.RenderWithoutMenu();
                Thread.Sleep(250);
            };
            _gameScreen.Render();
        }

        private void MoveViewUp(int value = 1)
        {
            _gameScreen.WorldViewOffsetY -= value;
            _gameScreen.Render();
        }

        private void MoveViewDown(int value = 1)
        {
            _gameScreen.WorldViewOffsetY += value;
            _gameScreen.Render();
        }

        private void MoveViewLeft(int value = 1)
        {
            _gameScreen.WorldViewOffsetX -= value;
            _gameScreen.Render();
        }

        private void MoveViewRight(int value = 1)
        {
            _gameScreen.WorldViewOffsetX += value;
            _gameScreen.Render();
        }
        private void NextGeneration()
        {
            Engine.GetInstance().World.NextGeneration();
            _prevGenerationButton.Active = true;
            _gameScreen.Render();
        }

        private void PrevGeneration()
        {
            _prevGenerationButton.Active = false;
            Engine.GetInstance().World.PrevGeneration();
            _gameScreen.Render();
        }

        private void SkipGenerations()
        {
            Console.WriteLine($"{Environment.NewLine}[Calculating...]");
            Engine.GetInstance().World.NextGeneration(50);
            _prevGenerationButton.Active = false;
            _gameScreen.Render();
        }

        private void NewWorld()
        {
            Engine.GetInstance().GenerateNewWorld();
            _gameScreen.Render();
        }

        private void GoToMainMenu()
        {
            new MainMenuScreen().Render();
        }
    }
}
