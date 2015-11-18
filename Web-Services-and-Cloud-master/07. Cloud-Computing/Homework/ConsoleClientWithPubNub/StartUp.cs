using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientWithPubNub
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ClientPubNub client = new ClientPubNub();

            client.NewMessageReceive += x => Console.WriteLine(x);

            client.Connect();

            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");
            client.SendMessage("test");


            Console.ReadKey();
            client.Disconnect();
        }
    }
}
