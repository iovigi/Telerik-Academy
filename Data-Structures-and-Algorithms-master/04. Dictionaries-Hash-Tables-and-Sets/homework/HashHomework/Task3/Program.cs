using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = File.ReadAllText("words.txt");

            var words = text.Split(' ', ',', '.', '!', ';', ':', '?').Select(x => x.ToLower());

            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                int size = 0;
                wordDictionary.TryGetValue(word, out size);

                wordDictionary[word] = ++size;
            }

            foreach (var kv in wordDictionary)
            {
                Console.WriteLine("{0} -> {1}", kv.Key, kv.Value);
            }
        }
    }
}
