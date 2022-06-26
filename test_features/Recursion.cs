using System;
using System.Threading;
using System.Text;
namespace test_features;

public static class Recursion
{
    public static void PrintNumbersSubstractByOne(int num, int end = 0)
    {
        WriteLine(num);
        if (num <= end) return;
        PrintNumbersSubstractByOne(num - 1, end);
    }
    public static int EvaluateFactorial(int num)
    {
        if (num == 0) return 1;
        return num * EvaluateFactorial(num - 1);
    }
    public static void PrintStringLoading(char[] chars, StringBuilder str, int delay = 100, int index_str = 0, int index_char = 0)
    {
        if (index_str >= str.Length)
        {
            PrintStringLoading(chars, str, delay, 0, index_char + 1);
            return;
        }
        if (index_char >= chars.Length) { return; }

        str[index_str] = chars[index_char];
        WriteLine(str);

        Thread.Sleep(delay);
        Console.Clear();
        PrintStringLoading(chars, str, delay, index_str + 1, index_char);
    }
    public static void PrintParantatheis(int l, int r, int n, string str = "")
    {
        if (l == n && r == n) WriteLine(str);
        if (l < n)
            PrintParantatheis(l + 1, r, n, new(str + "("));
        if (r < l)
            PrintParantatheis(l, r + 1, n, new(str + ")"));
    }
}

