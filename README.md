# Priority Queue with a min heap
Priority queue implemented as min-heap (dequeueing on basis of priority only; FIFO not guaranteed)

## Why?
In my A level Computer Science class, we learnt about priority queues, but every implementation that was shown used a simple array, requiring enqueue operations with a worst-case time complexity of $O(n)$. That's really unsatisfying and you can tell that priority queues aren't really best done like that.

Turns out, C# uses a min-heap data structure instead- it can be stored as a simple array but the enqueueing and dequeueing has a worst case time complexity of $`O(\log\,n)`$, which is great stuff! Technically it's a bit more specific than just a simple min-heap, but a simple min-heap priority queue is what I implement here.
