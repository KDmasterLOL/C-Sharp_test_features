using System.Collections;
using System.Diagnostics;

namespace DataStructure;

class StackLinkedNode<T> : IEnumerable
{
    private LinkedListNode<T> _node = null;
    private int _top = 0;

    public StackLinkedNode(params T[] items)
    {
        foreach (var item in items)
            Push(item);
    }
    public bool IsEmpty => _top == 0;

    public void Push(T value)
    {
        var item = new LinkedListNode<T>(value);
        item.Next = _node;
        _node = item;
        _top++;

    }
    public T Pop()
    {
        if (IsEmpty) return default;
        else
        {
            var item = _node;
            _node = item.Next;
            _top--;

            return item.Value;
        }
    }
    public override string ToString()
    {
        string str = $"Stack top - {_top}\nStack elements - ";
        foreach (var item in this)
            str = str.Insert(str.Length, $"{item}\t");
        return str;
    }

    public IEnumerator GetEnumerator() => new LinkedNodeEnumerator<T>(_node);
}

public class LinkedListNode<T>
{
    public LinkedListNode<T> Next { get; set; }
    public T Value { get; init; }

    public LinkedListNode(T value) => Value = value;
}

public class LinkedNodeEnumerator<T> : IEnumerator
{
    private LinkedListNode<T> _node;
    public LinkedNodeEnumerator(LinkedListNode<T> node) => _node = node;

    public object Current { get; private set; }

    public bool MoveNext()
    {
        if (_node is null) return false;
        Current = _node.Value;
        _node = _node.Next;
        return true;
    }

    public void Reset() { }
}

public class SimpleArrayQueue<T>
{
    private int _size, _rear = 0, _front = 0;

    private T[] _items;

    public int Length => _rear - _front;

    public bool IsFull => _size == _front - 1;
    public bool IsEmpty => _rear == 0;

    public T Rear
    {
        set => _items[_rear++] = value;
    }

    public T Front
    {
        get
        {
            if (_front < _size || _front <= _rear) _front++;
            return _items[_front - 1];
        }
    }
    public T Peek => _items[_front];

    public SimpleArrayQueue(int size = 5)
    {
        _size = size;
        _items = new T[_size];
    }

    public void Push(T item) => Rear = item;
    public T Pop() => Front;
}

class SimpleNodeQueue<T>
{
    private int _length = 0;
    private QueueNode _frontNode, _rearNode;

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
            var value = _frontNode.Value;
            _frontNode = _frontNode.next_node;
            return value;
        }
    }

    public void Push(T value)
    {
        _frontNode = new QueueNode(value);
        if (_length == 0) _rearNode = _frontNode;

        _length++;
    }
    public T Pop() => Front;
}

class CircularArrayQueue<T>
{
    private int _front = 0, _rear = 0, _size;
    private T[] _items;

    public CircularArrayQueue(int size = 10)
    {
        _size = size;
        _items = new T[_size];
    }
    public T Rear
    {
        set
        {
            if (_rear + 1 == _front) throw new Exception();
            _rear++;
            if (_rear == _size) _rear = 0;
            _items[_rear - 1] = value;
        }
    }
    public T Front
    {
        get
        {

            if (_front == _rear) throw new Exception();
            _front++;
            if (_front == _size) _front = 0;
            return _items[_front - 1];
        }
    }

    public void Push(T item) => Rear = item;
    public T Pop() => Front;
}

class LinkedList<T>
{
    class Node
    {
        public Node Next { get; set; }
        public T Value { get; }

        public Node(T value) => Value = value;
    }

    private Node _head, _tail;
    private int _size = 0;
    public void Push(T value)
    {
        if (_size == 0)
            _head = _tail = new Node(value);
        else
        {
            var last_head = _head;
            _head = new Node(value);
            _head.Next = last_head;
        }
        _size++;
    }

    public T Pop()
    {
        var value = _head.Value;
        _head = _head.Next;
        return value;
    }

    public T Peek() => _head.Value;
}