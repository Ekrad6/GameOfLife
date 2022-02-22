namespace GameOfLife.Extensions;

public static class StringExtensions
{
    public static string Repeat(this string value, int repetitions)
    {
        string result = "";
        for (int i = 0; i < repetitions; i++)
        {
            result += value;
        }
        return result;
    }
}
