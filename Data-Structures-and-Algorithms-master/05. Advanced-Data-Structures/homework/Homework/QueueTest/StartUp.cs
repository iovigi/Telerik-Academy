namespace QueueTest
{
    using QueueLibrary;
    using System;
    using System.Diagnostics;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            for (int i = 0; i < 1000; i++)
            {
                priorityQueue.Enqueue(rand.Next());
            }

            int prev = int.MinValue;

            while(!priorityQueue.IsEmpty)
            {
                var current = priorityQueue.Dequeue();

                if(current < prev)
                {
                    throw new ArgumentException("current < prev");
                }

                prev = current;
            }
        }
    }
}
