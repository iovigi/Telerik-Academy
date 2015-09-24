using System;

namespace Strategy
{
    class AirPlane : VehicleStrategy
    {
        public override void Move()
        {
            Console.WriteLine("Person travel with air plane");
        }
    }
}
