using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array = new double[] {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};
            Dictionary<double,int> timesOfNumber = new Dictionary<double, int>();

            foreach (var item in array)
            {
                int size = 0;
                timesOfNumber.TryGetValue(item, out size);

                timesOfNumber[item] = ++size;
            }

            foreach (var kv in timesOfNumber.OrderBy(x=> x.Key))
            {
                Console.WriteLine("{0} -> {1} times", kv.Key, kv.Value);
            }
        }
    }
}
