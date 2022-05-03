using System.Collections.Generic;
namespace test_features;

class Algorithms
{
    static public T[] BubbleSort<T>(in T[] source_array, bool debug = false) where T : IComparable<T>
    {
        var new_array = new T[source_array.Length];
        Array.Copy(source_array, new_array, source_array.Length);
        for (int step = 0; step < source_array.Length; step++)
        {
            bool is_change = false;
            for (int index = 1; index < source_array.Length - step; index++)
            {

                int last_index = index - 1;
                if (new_array[index].CompareTo(new_array[last_index]) > 0)
                {
                    (new_array[index], new_array[last_index]) = (new_array[last_index], new_array[index]);
                    is_change = true;
                }
            }
            if (debug)
            {
                Write($"Iteration {step + 1} array - ");
                foreach (var num in new_array) Write($"{num} ");
                WriteLine();
            }
            if (!is_change) break;
        }
        return new_array;
    }
}