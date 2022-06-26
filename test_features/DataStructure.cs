using System.Collections;
using System.Diagnostics;

namespace DataStructure;

class StackLinkedNode<T> : IEnumerable
{
    private LinkedListNode<T> node = null;
    private int top = 0;

    public StackLinkedNode(params T[] items)
    {
        foreach (var item in items)
            Push(item);
    }
    public bool IsEmpty => top == 0;

    public void Push(T value)
    {
        var item = new LinkedListNode<T>(value);
        item.Next = node;
        node = item;
        top++;

    }
    public T Pop()
    {
        if (IsEmpty) return default;
        else
        {
            var item = node;
            node = item.Next;
            top--;

            return item.Value;
        }
    }
    public override string ToString()
    {
        string str = $"Stack top - {top}\nStack elements - ";
        foreach (var item in this)
            str = str.Insert(str.Length, $"{item}\t");
        return str;
    }

    public IEnumerator GetEnumerator() => new LinkedNodeEnumerator<T>(node);
}

public class LinkedListNode<T>
{
    public LinkedListNode<T> Next { get; set; }
    public T Value { get; init; }

    public LinkedListNode(T value) => Value = value;
}

public class LinkedNodeEnumerator<T> : IEnumerator
{
    private LinkedListNode<T> node;
    public LinkedNodeEnumerator(LinkedListNode<T> node) => this.node = node;

    public object Current { get; private set; }

    public bool MoveNext()
    {
        if (node is null) return false;
        Current = node.Value;
        node = node.Next;
        return true;
    }

    public void Reset() { }
}

public class SimpleArrayQueue<T>
{
    private int _size, _rear = 0, _front = 0;

    private T[] items;

    public int Length => _rear - _front;

    public bool IsFull => _size == _front - 1;
    public bool IsEmpty => _rear == 0;

    public T Rear
    {
        set => items[_rear++] = value;
    }

    public T Front
    {
        get
        {
            if (_front < _size || _front <= _rear) _front++;
            return items[_front - 1];
        }
    }
    public T Peek => items[_front];

    public SimpleArrayQueue(int size = 5)
    {
        _size = size;
        items = new T[_size];
    }

    public void Push(T item) => Rear = item;
    public T Pop() => Front;
}

class SimpleNodeQueue<T>
{
    private int length = 0;
    private QueueNode frontNode, rearNode;

    class QueueNode
    {
        public QueueNode next_node;
        public T Value { get; }

        public QueueNode(T value) => Value = value;
    }

    public T Front
    {
        get
        {
            var value = frontNode.Value;
            frontNode = frontNode.next_node;
            return value;
        }
    }

    public void Push(T value)
    {
        frontNode = new QueueNode(value);
        if (length == 0) rearNode = frontNode;

        length++;
    }
    public T Pop() => Front;
}

class CircularArrayQueue<T>
{
    private int front = 0, rear = 0, size;
    private T[] items;

    public CircularArrayQueue(int size = 10)
    {
        this.size = size;
        items = new T[this.size];
    }
    public T Rear
    {
        set
        {
            if (rear + 1 == front) throw new Exception();
            rear++;
            if (rear == size) rear = 0;
            items[rear - 1] = value;
        }
    }
    public T Front
    {
        get
        {

            if (front == rear) throw new Exception();
            front++;
            if (front == size) front = 0;
            return items[front - 1];
        }
    }

    public void Push(T item) => Rear = item;
    public T Pop() => Front;
}

class SinglyLinkedList<T>
{
    class Node
    {
        public Node Next { get; set; }
        public T Value { get; }

        public Node(T value) => Value = value;
    }

    private Node head, tail;
    private int size = 0;

    public void Push(T value)
    {
        if (size == 0)
            head = tail = new Node(value);
        else
        {
            var last_head = head;
            head = new Node(value);
            head.Next = last_head;
        }
        size++;
    }
    public void InsertToEnd(T value)
    {
        if (size == 0)
        {
            Push(value);
            return;
        }
        else
        {
            tail.Next = new Node(value);
            tail = tail.Next;
        }
        size++;
    }
    public T Pop()
    {
        var value = head.Value;
        head = head.Next;
        return value;
    }
    public T Peek() => head.Value;
}

public class Tree<T> where T : IComparable
{
    private bool _debug;

    public Tree<T> Left { get; private set; }
    public Tree<T> Right { get; private set; }
    public T Value { get; private set; }

    public Tree(T value, bool debug = false) => (Value, _debug) = (value, debug);

    public void Add(T value)
    {
        if (_debug) WriteLine("Try add {0} value", value);
        if (Value.CompareTo(value) == 0) return;
        var new_tree = new Tree<T>(value);
        if (_debug) Write("Value {0} added ", value);
        switch (Value.CompareTo(value))
        {
            case -1:
                if (_debug) Write("in right\n");
                if (Right is null)
                    Right = new_tree;
                else
                    Right.Add(value);
                break;
            case 1:
                if (_debug) Write("in left\n");
                if (Left is null)
                    Left = new_tree;
                else
                    Left.Add(value);
                break;
        }

    }
}
