using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TreeBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfNodes;

            if (!int.TryParse(Console.ReadLine(), out numbersOfNodes))
            {
                return;
            }

            Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
            Node<int> root = null;

            for (int i = 0; i < numbersOfNodes; i++)
            {
                var line = Console.ReadLine();
                var lineItems = line.Split(' ');

                var parent = int.Parse(lineItems[0]);
                var child = int.Parse(lineItems[1]);

                Node<int> parentNode;

                if(!nodes.TryGetValue(parent,out parentNode))
                {
                    parentNode = new Node<int>(parent);
                    nodes.Add(parent, parentNode);
                }

                Node<int> childNode;

                if (!nodes.TryGetValue(child, out childNode))
                {
                    childNode = new Node<int>(child);
                    nodes.Add(child, childNode);
                }

                parentNode.Children.Add(childNode);

                if(root == null || root == childNode)
                {
                    root = parentNode;
                }
            }

            Console.WriteLine("Root is {0}", root.Value);

            var leafNodes = nodes.Where(x => x.Value != root && x.Value.Children.Count == 0).Select(x => x.Value.Value.ToString());
            Console.WriteLine("All leaf nodes is:{0}", string.Join(",", leafNodes));

            var middleNodes = nodes.Where(x => x.Value != root && x.Value.Children.Count > 0).Select(x => x.Value.Value.ToString());
            Console.WriteLine("All middle nodes is:{0}", string.Join(",", middleNodes));
        }
    }
}
