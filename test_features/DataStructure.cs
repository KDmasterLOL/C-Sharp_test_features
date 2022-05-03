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
public class LinkedList<T> : IEnumerable
{
    private int _count = 0;
    public LinkedListNode<T> Head { get; private set; }
    public LinkedListNode<T> Tail { get; private set; }

    public LinkedList(params T[] items)
    {
        if (items.Length == 0) return;
        Add(items);
    }
    public void Add(T value)
    {
        if (_count == 0)
            Tail = Head = new LinkedListNode<T>(value);
        else
        {
            var node = new LinkedListNode<T>(value) { Next = Head };
            Head = node;
        }
        ++_count;
    }
    public void Add(params T[] values)
    {
        foreach (var value in values)
            Add(value);
    }

    public IEnumerator GetEnumerator()
    {
        return new LinkedNodeEnumerator<T>(Head);
    }

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

    public void Enqueue(T item) => _items[_rear++] = item;
    public T Dequeue() => Front;
}