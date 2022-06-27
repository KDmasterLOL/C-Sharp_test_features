//test_features.Recursion.PrintStringLoading(new char[] { 'z','a' }, new("--------"),200);
//test_features.TestStructures.TestTraverseTree();
var ar = new int[] { 2, 1, 0, -1, 5 };
ar = test_features.Algorithms.Sorting.QuickSort(ar, 0, ar.Length-1);
WriteLine(String.Join(" ", ar));
