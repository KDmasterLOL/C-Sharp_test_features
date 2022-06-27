using System.Collections.Generic;
namespace test_features;

static class Algorithms
{
    static public class Sorting
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
        static public T[] QuickSort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (end - start + 1 < 2) return array;

            int pivot = start;
            T temp;
            for (int i = start + 1; i <= end; i++)
            {
                if (array[pivot].CompareTo(array[i]) == 1)
                {
                    if (pivot + 1 == i)
                    {
                        temp = array[pivot];
                        array[pivot] = array[i];
                        array[i] = temp;
                    }
                    else
                    {
                        temp = array[pivot + 1];
                        array[pivot + 1] = array[pivot];
                        array[pivot] = array[i];
                        array[i] = temp;
                    }
                    pivot++;
                }
            }

            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
            return array;
        }
    }
    static public int BinarySearch<T>(in T[] array, T target, bool debug = true) where T : IComparable<T>
    {
        int high, low, mid;
        high = array.Length - 1;
        low = 0;

        if (debug) WriteLine($"Start binary search - array length({array.Length})");

        while (low <= high)
        {
            mid = low + ((high - low) / 2);

            if (debug) WriteLine($"Low - {low}\thigh - {high}\tmid - {mid}");

            switch (array[mid].CompareTo(target))
            {
                case 0:
                    if (debug) WriteLine($"Element {target} was found at index {mid}");
                    return mid;
                case 1:
                    high = mid - 1;
                    break;
                case -1:
                    low = mid + 1;
                    break;
            }
        }
        if (debug) WriteLine($"{target} not found in array({string.Join(" ", array)})");
        return -1;
    }
    static public void TowerOfHanoi()
    {
        /* 
         * PseudoCode 4 disks:
         * Move 1 on aux tower
         * Move 2 on dest tower
         * Move 1 on dest tower
         * Move 3 on aux tower
         * Move 1 on start tower
         * Move 2 on aux tower
         * Move 1 on aux tower
         * Move 4 on dest tower
         * Move 1 on dest tower
         * Move 2 on start tower
         * Move 1 on start tower
         * Move 3 on dest tower
         * Move 1 on aux tower
         * Move 2 on dest tower
         * Move 1 on dest tower
         */

    }
    static public int EuclideanAlgorithm(int first, int second, bool debug = false)
    {
        var (max, min) = (Max(first, second), Min(first, second));
        if (debug) WriteLine("max - {0}, min - {1}", max, min);
        if (max % min == 0) return min;
        if (max / min == 0) return 0;
        return EuclideanAlgorithm(min, max % min, debug);
    }
}