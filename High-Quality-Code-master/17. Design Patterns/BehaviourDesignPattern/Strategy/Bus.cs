using System;

namespace Strategy
{
    public class Bus : VehicleStrategy
    {
        public override void Move()
        {
            Console.WriteLine("Person travel with bus");
        }
    }
}
