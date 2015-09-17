namespace Device
{
    using System;

    public class Linux : IOperationSystem
    {
        public void Execute()
        {
            Console.WriteLine("Execute linux");
        }
    }
}
