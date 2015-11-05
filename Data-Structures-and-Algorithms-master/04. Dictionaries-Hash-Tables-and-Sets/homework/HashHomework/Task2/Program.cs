using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] array = new[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL"};
            Dictionary<string,int> words = new Dictionary<string, int>();

            foreach (var item in array)
            {
                int size = 0;
                words.TryGetValue(item, out size);

                words[item] = ++size;
            }

            Console.WriteLine(String.Join(",", words.Where(x => x.Value%2 != 0).Select(x => x.Key)));
        }
    }
}
