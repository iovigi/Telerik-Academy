namespace ConsoleClientWithIronMQ
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IronMQClient client = new IronMQClient();

            client.NewMessageReceive += x => Console.WriteLine(x);

            client.Connect();

            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");

            client.Disconnect();
        }
    }
}
