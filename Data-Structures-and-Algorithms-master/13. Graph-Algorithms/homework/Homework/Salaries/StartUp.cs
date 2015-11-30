namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                edges.Add(new Edge());
            }

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        edges[i].Edges.Add(edges[j]);
                    }
                }

                if (edges[i].Edges.Count == 0)
                {
                    edges[i].Salary = 1;
                }
            }

            long salary = 0;

            foreach (var vertex in edges)
            {
                salary += GetSalary(vertex);
            }

            Console.WriteLine(salary);
        }

        private static long GetSalary(Edge vertex)
        {
            if (vertex.Salary == 0)
            {
                foreach (var v in vertex.Edges)
                {
                    vertex.Salary += GetSalary(v);
                }
            }

            return vertex.Salary;
        }
    }
}
