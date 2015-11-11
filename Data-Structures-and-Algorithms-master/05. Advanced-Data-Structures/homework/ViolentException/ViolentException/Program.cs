using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolentException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new AccessViolationException();
            }
            catch
            {

            }
        }
    }
}
