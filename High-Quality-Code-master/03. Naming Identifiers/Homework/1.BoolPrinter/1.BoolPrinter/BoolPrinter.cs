using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.BoolPrinter
{
    public class BoolPrinter
    {
        public const int MAX_COUNT = 6;

        public static void Print()
        {
            Printer printer = new Printer();

            printer.Print(true);
        }
    }
}
