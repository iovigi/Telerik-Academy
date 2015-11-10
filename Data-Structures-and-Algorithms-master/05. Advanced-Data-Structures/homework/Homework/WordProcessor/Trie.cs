﻿/*
    The MIT License (MIT)
    Copyright (c) 2013
 
    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
    to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
    The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace WordProcessor
{

    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    public class Trie
    {
        public Node RootNode { get; private set; }

        public Trie()
        {
            RootNode = new Node { Letter = Node.Root };
        }

        public void Add(string word)
        {
            word = word.ToLower() + Node.Eow;
            var currentNode = RootNode;
            foreach (var c in word)
            {
                currentNode = currentNode.AddChild(c);
            }
        }

        public List<string> Match(string prefix, int? maxMatches)
        {
            prefix = prefix.ToLower();

            var set = new HashSet<string>();

            _MatchRecursive(RootNode, set, "", prefix, maxMatches);
            return set.ToList();
        }

        private static void _MatchRecursive(Node node, ISet<string> rtn, string letters, string prefix, int? maxMatches)
        {
            if (maxMatches != null && rtn.Count == maxMatches)
                return;

            if (node == null)
            {
                if (!rtn.Contains(letters)) rtn.Add(letters);
                return;
            }

            letters += node.Letter.ToString();

            if (prefix.Length > 0)
            {
                if (node.ContainsKey(prefix[0]))
                {
                    _MatchRecursive(node[prefix[0]], rtn, letters, prefix.Remove(0, 1), maxMatches);
                }
            }
            else
            {
                foreach (char key in node.Keys)
                {
                    _MatchRecursive(node[key], rtn, letters, prefix, maxMatches);
                }
            }
        }
    }
    public class Node
    {
        public const char Eow = '$';
        public const char Root = ' ';

        public char Letter { get; set; }
        public HybridDictionary Children { get; private set; }

        public Node() { }

        public Node(char letter)
        {
            this.Letter = letter;
        }

        public Node this[char index]
        {
            get { return (Node)Children[index]; }
        }

        public ICollection Keys
        {
            get { return Children.Keys; }
        }

        public bool ContainsKey(char key)
        {
            return Children.Contains(key);
        }

        public Node AddChild(char letter)
        {
            if (Children == null)
                Children = new HybridDictionary();

            if (!Children.Contains(letter))
            {
                var node = letter != Eow ? new Node(letter) : null;
                Children.Add(letter, node);
                return node;
            }

            return (Node)Children[letter];
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}
