namespace TaskFourIISClient
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            WordServiceClient client = new WordServiceClient();
            var count = client.GetTimesOfMuch("i", "iii");

            Console.WriteLine(count);
        }
    }
}
