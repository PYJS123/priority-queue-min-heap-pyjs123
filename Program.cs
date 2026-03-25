namespace PriorityQueueMinHeap;

class Program
{
    static void Main(string[] args)
    {
        MyPriorityQueue<string> pq = new(100);

        // string[] sentence = "Samuel Abraham went to France to serve the king of Normandy by fighting in the Bronze Age using a Time Machine Built by “Sir Aren Ate A Wall” but it malfunctioned and killed Lineel".Split(' ');

        Random r = new();
        // int added = 0;
        // while (added < sentence.Length)
        // {
        //     int index = r.Next(0, sentence.Length);
        //     if (sentence[index] != "")
        //     {
        //         pq.Enqueue(sentence[index], index);
        //         Console.WriteLine($"Added: {sentence[index]} ({index})");
        //         sentence[index] = "";
        //         added++;
        //     }
        // }

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
