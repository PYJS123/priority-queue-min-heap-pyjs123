namespace PriorityQueueMinHeap;

class Program
{
    static void Main(string[] args)
    {
        MyPriorityQueue<string> pq = new(100);

        for (int i = 0; i < pq.MaxLength; i++)
        {
            (string, int) toBeAdded = (Convert.ToString(DateTime.Now.Nanosecond.GetHashCode()), r.Next(1, 21));
            pq.Enqueue(toBeAdded.Item1, toBeAdded.Item2);
            Console.WriteLine($"Added: {toBeAdded.Item1} ({toBeAdded.Item2})");
        }

        Console.Write("Proceed?");
        Console.ReadLine();
        Console.Clear();
        int size = pq.Size;
        for (int i = 0; i < size; i++)
        {
            (string, int) dequeued = pq.Dequeue();
            Console.WriteLine($"{dequeued.Item1} ({dequeued.Item2})");
            if ((i + 1) % 10 == 0)
            {
                Console.Write("Proceed?");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
