using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device
{
    class Phone : IDevice
    {
        public IOperationSystem OperationSystem { get; set; }

        public void Start()
        {
            Console.WriteLine("Start Phone");

            if (OperationSystem != null)
            {
                OperationSystem.Execute();
            }
        }
    }
}
