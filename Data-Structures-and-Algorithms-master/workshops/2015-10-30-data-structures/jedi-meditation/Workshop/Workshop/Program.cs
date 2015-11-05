using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] jedis = Console.ReadLine().Split(' ');

            var jediMasters = jedis.Where(x => x.Contains("m"));
            var jediKnights = jedis.Where(x => x.Contains("k"));
            var padawans = jedis.Where(x => x.Contains("p"));

            Console.WriteLine("{0} {1} {2}",string.Join(" ",jediMasters),string.Join(" ",jediKnights), string.Join(" ", padawans));
        }
    }
}
