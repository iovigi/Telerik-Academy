namespace Salaries
{
    using System.Collections.Generic;

    public class Edge
    {
        public long Salary;

        public readonly List<Edge> Edges = new List<Edge>();
    }
}
