using GameOfLife.Extensions;

namespace GameOfLife.Logic.Worlds;

public class World
{
    public bool[,] Matrix { get; private set; }
    public bool[,]? PrevMatrix { get; private set; }
    public WorldStats Stats { get; private set; }

    public World(bool[,] matrix)
    {
        Matrix = matrix;
        Stats = new WorldStats(this);
    }

    public World(int width, int heigth)
    {
        GenerateMatrix(width, heigth);
        Stats = new WorldStats(this);

    }

    private void GenerateMatrix(int width, int heigth)
    {
        RandomBool randomBool = new();
        var matrix = new bool[width, heigth];

        for (int i = 0; i < heigth; i++)
        {
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = randomBool.NextBool();
            }
        }

        Matrix = matrix;
    }

    public void NextGeneration(int skip = 0)
    {
        if (skip == 0)
        {
            SavePrevGeneration();
        }

        bool[] lineBuffor = new bool[Matrix.GetLength(0)];
        bool[] nextLineBuffor = new bool[Matrix.GetLength(0)];

        for (int i = 0; i < (skip == 0 ? 1 : skip); i++)
        {
            for (int x = 0; x < Matrix.GetLength(1); x++)
            {
                lineBuffor[x] = CalculateCell(x, 0);
            }

            for (int y = 1; y < Matrix.GetLength(0); y++)
            {
                for (int x = 0; x < Matrix.GetLength(1); x++)
                {
                    nextLineBuffor[x] = CalculateCell(x, y);
                }

                Matrix.InsertRow(lineBuffor, y - 1);
                lineBuffor = nextLineBuffor;
            }

            Matrix.InsertRow(nextLineBuffor, Matrix.GetLength(0) - 1);

        }

        Stats.Update(this, skip);
    }

    private void SavePrevGeneration()
    {
        if (PrevMatrix == null)
        {
            PrevMatrix = new bool[Stats.Heigth, Stats.Width];
        }
        Array.Copy(Matrix, PrevMatrix, Matrix.Length);
    }

    public void PrevGeneration()
    {
        if(PrevMatrix == null)
        {
            return;
        }

        Matrix = PrevMatrix;
        PrevMatrix = null;
        Stats.Update(this,prevGeneration: true);
    }

    private bool CalculateCell(int cellX, int cellY)
    {
        int sum = 0;
        for (int i = cellY - 1; i <= cellY + 1; i++)
        {
            for (int j = cellX - 1; j <= cellX + 1; j++)
            {
                int x = j;
                if (x < 0)
                {
                    x = Matrix.GetLength(1) - 1;
                }
                else if (x >= Matrix.GetLength(1))
                {
                    x = 0;
                }

                int y = i;
                if (y < 0)
                {
                    y = Matrix.GetLength(0) - 1;
                }
                else if (y >= Matrix.GetLength(0))
                {
                    y = 0;
                }

                sum += Matrix[y, x] ? 1 : 0;
            }
        }

        return sum switch
        {
            3 => true,
            4 => Matrix[cellY, cellX],
            _ => false,
        };
    }

}
