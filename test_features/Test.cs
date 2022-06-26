namespace test_features;

using DataStructure;

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
        var linkedList = new DataStructure.SinglyLinkedList<int>();

        linkedList.Push(10);
        linkedList.Push(20);
        linkedList.Push(30);
        linkedList.Push(40);

        WriteLine($"{linkedList.Pop()}");
        WriteLine($"{linkedList.Pop()}");
        WriteLine($"{linkedList.Pop()}");
    }
    static public void TestTraverseTree()
    {
        var values = new int[] { 2, 3, 5, 12, 20 };
        var tree = new Tree<int>(10, true);
        foreach (var val in values)
            tree.Add(val);
        WriteLine("InOrder Traverse");
        TreeTraverse.InOrder(tree);
        WriteLine("PreOrder Traverse");
        TreeTraverse.PreOrder(tree);
        WriteLine("PostOrder Traverse");
        TreeTraverse.PostOrder(tree);
    }
}

static public class TestAlgorithms
{
    static public void TestBinarySearch()
    {
        int[] array = new int[] { 10, 20, 30, 49, 60 };
        WriteLine($"{array[Algorithms.BinarySearch(array, array[^2], true)]} ");
    }
}
static public class Test
{
    [Flags]
    enum my_enum
    {
        b = 1,
        a = 2,
        c = 4,
        r = 8,
    }

    static public void Enum()
    {
        my_enum en = my_enum.b | my_enum.a;
        en |= my_enum.r;
        switch (en)
        {
            case my_enum.b:
                WriteLine("IT'S b");
                break;
            case my_enum.a:
                WriteLine("IT'S a");
                break;
            case my_enum.b | my_enum.a | my_enum.r:
                WriteLine("IT'S b and a and r");
                break;
        }
    }
}