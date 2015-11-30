namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lineItems = Console.ReadLine().Split(' ');

            int n = int.Parse(lineItems[0]);
            int m = int.Parse(lineItems[1]);
            int h = int.Parse(lineItems[2]);

            

            int[] startPoints = new int[h];
            lineItems = Console.ReadLine().Split(' ');

            for (int i = 0; i < h; i++)
            {
                startPoints[i] = int.Parse(lineItems[i]);
            }


            List<Edge>[] edges = new List<Edge>[n + 1];

            for (int i = 0; i < m; i++)
            {
                lineItems = Console.ReadLine().Split(' ');
                int v1 = int.Parse(lineItems[0]);
                int v2 = int.Parse(lineItems[1]);
                int weight = int.Parse(lineItems[2]);

                if (edges[v1] == null)
                {
                    edges[v1]= new List<Edge>();
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

            int minPath = int.MaxValue;

            for (int i = 0; i < h; i++)
            {
                int[] paths = new int[n + 1];
                for (int j = 1; j <= n; j++)
                {
                    paths[j] = int.MaxValue;
                }

                paths[startPoints[i]] = 0;

                GetPath(startPoints[i], edges, paths);
                for (int j = 0; j < h; j++)
                {
                    paths[startPoints[j]] = 0;
                }

                var pathLength = paths.Sum();

                if (pathLength < minPath)
                {
                    minPath = pathLength;
                }
            }

            Console.WriteLine(minPath);
        }

        private static void GetPath(int v, List<Edge>[] edges,int[] path)
        {
            var queue = new Queue<Edge>();
            queue.Enqueue(new Edge() {ToVertex = v, Weight = 0});

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
