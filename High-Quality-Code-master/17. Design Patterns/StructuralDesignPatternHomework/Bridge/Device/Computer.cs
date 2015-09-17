using System;

namespace Device
{
    public class Computer : IDevice
    {
        public IOperationSystem OperationSystem { get; set; }

        public void Start()
        {
            Console.WriteLine("Start Computer");

            if(OperationSystem != null)
            {
                OperationSystem.Execute();
            }
        }
    }
}
