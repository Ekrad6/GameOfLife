namespace GameOfLife.Logic.Worlds;

public class WorldStats
{
    public int Width { get; private set; }
    public int Heigth { get; private set; }
    public int CellsAlive { get; private set; }
    public int CellsDead { get; private set; }
    public int PercentAlive { get; private set; }
    public int Generation { get; private set; }

    public WorldStats(World world)
    {
        Width = world.Matrix.GetLength(0);
        Heigth = world.Matrix.GetLength(1);
        Generation = 0;
        CalculateCells(world.Matrix);
    }

    public void SkipGenerations(int skip)
    {
        Generation+=skip;
    }

    public void Update(World world, int skip = 0, bool prevGeneration = false)
    {
        CalculateCells(world.Matrix);
        if (prevGeneration)
        {
            Generation--;
        }
        else
        {
            Generation += skip == 0 ? 1 : skip;
        }
    }

    private void CalculateCells(bool[,] matrix)
    {
        CellsAlive = 0;
        CellsDead = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                _ = matrix[i, j] ? CellsAlive++ : CellsDead++;
            }
        }

        PercentAlive = (int)((decimal)CellsAlive / (matrix.GetLength(0) * matrix.GetLength(1)) * 100);
    }

}
