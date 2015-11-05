using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TreeBuild
{
    public class Node<T>
    {
        public readonly T Value;

        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public List<Node<T>> Children { get; private set; }
    }
}
