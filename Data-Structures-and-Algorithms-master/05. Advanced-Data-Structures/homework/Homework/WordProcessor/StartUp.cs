namespace WordProcessor
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bibleLines = File.ReadAllLines("bible.txt");

            Trie trie = new Trie();

            foreach (var line in bibleLines)
            {
                foreach (var word in line.Split('.', ' ', '!', '?', ','))
                {
                    trie.Add(word);
                }
            }

            var jesusCount = trie.Match("Иисус", null).Count;

            Console.WriteLine("Count of word Jesus in holy bible is {0}", jesusCount);
        }
    }
}
