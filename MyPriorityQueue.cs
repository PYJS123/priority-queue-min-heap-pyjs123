using System.ComponentModel.DataAnnotations;

namespace PriorityQueueMinHeap;

public class MyPriorityQueue<T>
{
    (T item, int priority)[] _items; // this will be a min heap
    int _heapSize = -1; // last index in use
    int _length;

    public MyPriorityQueue(int maxLength)
    {
        _items = new (T, int)[maxLength];
        _length = maxLength;
    }

    public int MaxLength { get => _length; }
    public int Size { get => _heapSize + 1; }

    public bool IsEmpty()
    {
        return _heapSize == -1;
    }

    public bool IsFull()
    {
        return _heapSize == _length - 1;
    }

    static int LChild(int nodeIndex)
    {
        return 2 * nodeIndex + 1;
    }

    static int RChild(int nodeIndex)
    {
        return 2 * nodeIndex + 2;
    }

    static int Parent(int nodeIndex)
    {
        return (nodeIndex - 1) / 2;
    }

    public void Enqueue(T item, int priority)
    {
        if (IsFull()) throw new OutOfMemoryException("Priority queue is full");

        _heapSize++;
        _items[_heapSize] = (item, priority);

        int currIndex = _heapSize;
        while (currIndex != 0 && _items[Parent(currIndex)].priority > priority)
        {
            (_items[Parent(currIndex)], _items[currIndex]) = (_items[currIndex], _items[Parent(currIndex)]);
            currIndex = Parent(currIndex);
        }
    }

    public (T, int) Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Priority queue is empty");

        (_items[0], _items[_heapSize]) = (_items[_heapSize], _items[0]);
        _heapSize--;

        // heapify

        return _items[_heapSize + 1];
    }
}
