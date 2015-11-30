namespace Cables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input path from house count");
            int n = int.Parse(Console.ReadLine());
            List<Edge>[] edges = new List<Edge>[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("get path(max house number is n-1)");

                var lineItems = Console.ReadLine().Split(' ');
                int v1 = int.Parse(lineItems[0]);
                int v2 = int.Parse(lineItems[1]);
                int weight = int.Parse(lineItems[2]);

                if (edges[v1] == null)
                {
                    edges[v1] = new List<Edge>();
                }

                edges[v1].Add(new Edge()
                {
                    ToVertex = v2,
                    Weight = weight
                });

                if (edges[v2] == null)
                {
                    edges[v2] = new List<Edge>();
                }

                edges[v2].Add(new Edge()
                {
                    ToVertex = v1,
                    Weight = weight
                });
            }

            int[] paths = new int[n + 1];
            GetPath(0, edges, paths);

            Console.WriteLine("Optimal oath is :{0}", paths.Sum());
        }

        private static void GetPath(int v, List<Edge>[] edges, int[] path)
        {
            var queue = new Queue<Edge>();
            queue.Enqueue(new Edge() { ToVertex = v, Weight = 0 });

            while (queue.Count != 0)
            {
                var currentVertex = queue.Dequeue();
                foreach (var edge in edges[currentVertex.ToVertex])
                {
                    var currentDistance = path[currentVertex.ToVertex] + edge.Weight;
                    if (currentDistance >= path[edge.ToVertex])
                    {
                        continue;
                    }

                    path[edge.ToVertex] = currentDistance;
                    queue.Enqueue(new Edge() { ToVertex = edge.ToVertex, Weight = currentDistance });
                }
            }
        }
    }
}
