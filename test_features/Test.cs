namespace test;

static public class Test
{
    static public void TestQueue()
    {
        var queue = new DataStructure.SimpleArrayQueue<int>(10);
        queue.Enqueue(10);
        queue.Enqueue(20);
        WriteLine($"{queue.Peek}");
        queue.Dequeue();
        WriteLine($"{queue.Peek}");
    }
}

