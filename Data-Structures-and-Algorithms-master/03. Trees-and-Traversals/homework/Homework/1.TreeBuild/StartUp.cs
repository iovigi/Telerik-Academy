using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TreeBuild
{
    public class StartUp
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

                if (!nodes.TryGetValue(parent, out parentNode))
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

                if (root == null || root == childNode)
                {
                    root = parentNode;
                }
            }

            Console.WriteLine("Root is {0}", root.Value);

            var leafNodes = nodes.Where(x => x.Value != root && x.Value.Children.Count == 0).Select(x => x.Value.Value.ToString());
            Console.WriteLine("All leaf nodes is:{0}", string.Join(",", leafNodes));

            var middleNodes = nodes.Where(x => x.Value != root && x.Value.Children.Count > 0).Select(x => x.Value.Value.ToString());
            Console.WriteLine("All middle nodes is:{0}", string.Join(",", middleNodes));

            var path = FindPath(root);

            foreach (var node in path)
            {
                Console.WriteLine(node.Value);
            }

            Console.WriteLine("Input sum:");
            var sum = int.Parse(Console.ReadLine());

            var paths = FindPathWithGivenSum(root, sum).Where(x => x.Sum(y => y.Value) == sum);

            foreach (var sumPath in paths)
            {
                Console.WriteLine("All path with sum {0} is:{1}", sum, string.Join(",", sumPath.Select(x => x.Value)));
            }

            foreach (var subTree in FindSubTree(root,sum).Where(x=> x.Sum(y=> y.Value) == sum))
            {
                Console.WriteLine("All sub tree with sum {0} is:{1}", sum, string.Join(",", subTree.Select(x => x.Value)));
            }
        }

        private static List<Node<int>> FindPath(Node<int> parentNode)
        {
            List<Node<int>> longPath = new List<Node<int>>();

            foreach (var child in parentNode.Children)
            {
                var findedPath = FindPath(child);

                if (findedPath.Count > longPath.Count)
                {
                    longPath = findedPath;
                }
            }

            longPath.Insert(0, parentNode);

            return longPath;
        }

        private static List<List<Node<int>>> FindPathWithGivenSum(Node<int> parentNode, int sum)
        {
            List<List<Node<int>>> paths = new List<List<Node<int>>>();

            if (parentNode.Children.Count == 0)
            {
                var resultPath = new List<Node<int>>();
                resultPath.Add(parentNode);

                paths.Add(resultPath);
            }
            else
            {
                foreach (var child in parentNode.Children)
                {
                    var resultPaths = FindPathWithGivenSum(child, sum)
                        .Where(x => x.Sum(y => y.Value) + parentNode.Value <= sum);

                    paths.AddRange(resultPaths);
                }
            }


            return paths;
        }

        private static List<List<Node<int>>> FindSubTree(Node<int> parentNode, int sum)
        {
            List<List<Node<int>>> resultSubTrees = new List<List<Node<int>>>();
            bool isSubTree = true;

            foreach (var child in parentNode.Children)
            {
                var childResultSubTree = FindSubTree(child, sum);
                resultSubTrees.AddRange(childResultSubTree);

                if (childResultSubTree.Count > 1)
                {
                    isSubTree = false;
                }
            }

            if (isSubTree)
            {
                List<Node<int>> resultSubTree = new List<Node<int>>();
                resultSubTree.Add(parentNode);

                foreach (var subTree in resultSubTrees)
                {
                    resultSubTree.AddRange(subTree); 
                }

                if (resultSubTree.Sum(x => x.Value) <= sum)
                {
                    resultSubTrees.Clear();

                    resultSubTrees.Add(resultSubTree);

                    return resultSubTrees;
                }
            }

            return resultSubTrees.Where(x => x.Sum(y => y.Value) == sum).ToList();
        }
    }
}
