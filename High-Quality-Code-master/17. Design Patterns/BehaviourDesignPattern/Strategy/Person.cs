namespace Strategy
{
    public class Person
    {
        public void Travel(VehicleStrategy vehicle)
        {
            vehicle.Move();
        }
    }
}
