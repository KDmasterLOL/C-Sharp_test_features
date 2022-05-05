namespace test;

static public class TestStructures
{
    static public void TestQueue()
    {
        var queue = new DataStructure.SimpleArrayQueue<int>(10);
        queue.Push(10);
        queue.Push(20);
        WriteLine($"{queue.Peek}");
        queue.Pop();
        WriteLine($"{queue.Peek}");
    }
    static public void TestCircularQueue()
    {
        var queue = new DataStructure.CircularArrayQueue<int>(3);
        queue.Push(10);
        queue.Push(20);
        queue.Push(30);
        WriteLine($"{queue.Pop()}");
        //queue.Push(40);
    }
    static public void TestLinkedList()
    {
        var linkedList = new DataStructure.LinkedList<int>();

        linkedList.Push(10);
        linkedList.Push(20);
        linkedList.Push(30);
        linkedList.Push(40);

        WriteLine($"{linkedList.Pop()}");
        WriteLine($"{linkedList.Pop()}");
        WriteLine($"{linkedList.Pop()}");
    }

}

static public class TestAlgorithms
{
    static public void TestBinarySearch()
    {
        int[] array = new int[] { 10, 20, 30, 49, 60 };
        WriteLine($"{array[Algorithms.BinarySearch(array, 30, true)]} ");
    }
}