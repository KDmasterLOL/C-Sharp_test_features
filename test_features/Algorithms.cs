using System.Collections.Generic;
namespace test;

class Algorithms
{
    static public void BubbleSort<T>(in T[] array, bool debug = false) where T : IComparable<T>
    {
        for (int step = 0; step < array.Length; step++)
        {
            bool is_change = false;
            for (int index = 1; index < array.Length - step; index++)
            {

                int last_index = index - 1;
                if (array[index].CompareTo(array[last_index]) > 0)
                {
                    (array[index], array[last_index]) = (array[last_index], array[index]);
                    is_change = true;
                }
            }
            if (debug)
            {
                Write($"Iteration {step + 1} array - ");
                foreach (var num in array) Write($"{num} ");
                WriteLine();
            }
            if (!is_change) break;
        }
    }
    static public int BinarySearch<T>(in T[] array, T target, bool debug = false) where T : IComparable<T>
    {
        int length, high, low = 0, mid = 0;
        length = high = array.Length;

        if (debug) WriteLine($"Start binary search - array length({array.Length})");

        while (low <= high)
        {
            mid = low + ((high - low) / 2);

            if (debug) WriteLine($"Low - {low}\thigh - {high}\tmid - {mid}");

            if (array[mid].CompareTo(target) == 0) return mid;
            else if (array[mid].CompareTo(target) == -1) low = mid + 1;
            else high = mid - 1;
        }
        return -1;
    }
}