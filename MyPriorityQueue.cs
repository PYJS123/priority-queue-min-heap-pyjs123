using System.ComponentModel.DataAnnotations;

namespace PriorityQueueMinHeap;

public class MyPriorityQueue<T>
{
    (T item, int priority)[] _items; // this will be a min heap
    int _heapEnd = -1; // last index in use
    int _length;

    public MyPriorityQueue(int maxLength)
    {
        _items = new (T, int)[maxLength];
        _length = maxLength;
    }

    public int MaxLength { get => _length; }
    public int Size { get => _heapEnd + 1; }

    public bool IsEmpty()
    {
        return _heapEnd == -1;
    }

    public bool IsFull()
    {
        return _heapEnd == _length - 1;
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
        if (IsFull()) throw new InvalidOperationException("Priority queue is full");

        _heapEnd++;
        _items[_heapEnd] = (item, priority);

        int currIndex = _heapEnd;
        while (currIndex != 0 && _items[Parent(currIndex)].priority > priority)
        {
            (_items[Parent(currIndex)], _items[currIndex]) = (_items[currIndex], _items[Parent(currIndex)]);
            currIndex = Parent(currIndex);
        }
    }

    public (T, int) Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Priority queue is empty");

        (_items[0], _items[_heapEnd]) = (_items[_heapEnd], _items[0]);
        _heapEnd--;

        int currIndex = 0;
        while (LChild(currIndex) <= _heapEnd)
        {
            int LChildPriority = _items[LChild(currIndex)].priority;
            int RChildPriority = RChild(currIndex) <= _heapEnd ? _items[RChild(currIndex)].priority : int.MaxValue;

            if (LChildPriority <= RChildPriority && LChildPriority < _items[currIndex].priority)
            {
                SwapWithLeftChild(ref currIndex, _items);
            }
            else if (RChildPriority < LChildPriority && RChildPriority < _items[currIndex].priority)
            {
                SwapWithRightChild(ref currIndex, _items);
            }
            else
            {
                break;
            }
        }

        return _items[_heapEnd + 1];
    }

    static void SwapWithLeftChild(ref int index, (T, int)[] items)
    {
        (items[LChild(index)], items[index]) = (items[index], items[LChild(index)]);
        index = LChild(index);
    }

    static void SwapWithRightChild(ref int index, (T, int)[] items)
    {
        (items[RChild(index)], items[index]) = (items[index], items[RChild(index)]);
        index = RChild(index);
    }
}
