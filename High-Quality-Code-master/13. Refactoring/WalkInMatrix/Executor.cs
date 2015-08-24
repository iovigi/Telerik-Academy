namespace WalkInMatrix
{
    using System;

    public class Executor
    {
        public static void Main()
        {
            int n = 6;

            GameEngine engine = new GameEngine(n);
            engine.Start();
            Console.WriteLine(engine.BoardToString());
        }
    }
}
