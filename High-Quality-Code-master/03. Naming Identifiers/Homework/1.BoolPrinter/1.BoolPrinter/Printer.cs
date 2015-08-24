using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.BoolPrinter
{
    public class Printer
    {
        public void Print(bool value)
        {
            string stringRepresentation = value.ToString();

            Console.WriteLine(stringRepresentation);
        }
    }
}
