using System;

namespace Strategy
{
    public class Car : VehicleStrategy
    {
        public override void Move()
        {
            Console.WriteLine("Person travel with car");
        }
    }
}
