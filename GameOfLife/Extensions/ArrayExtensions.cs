namespace GameOfLife.Extensions;

public static class ArrayExtensions
{
    public static void InsertRow(this bool[,] matrix, bool[] row, int rowNumber)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[rowNumber, i] = row[i];
        }
    }
}
