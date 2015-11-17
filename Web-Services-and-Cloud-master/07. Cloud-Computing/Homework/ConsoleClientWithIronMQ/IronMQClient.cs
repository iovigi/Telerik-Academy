namespace ConsoleClientWithIronMQ
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ClientLibrary;
    using IronMQ;

    public class IronMQClient : ClientBase
    {
        private Client client;
        private Queue queue;

        private Task receiver;
        private bool shutdown;

        public override void Connect()
        {
            this.client = new Client("564b5fdc9195a800070000e7", "mRhNH5sVa9jcitAm5nEX");
            this.queue = client.Queue("chat");
            this.shutdown = false;
            this.receiver = Task.Factory.StartNew(this.Receive);
        }

        public override void Disconnect()
        {
            this.shutdown = true;
            this.receiver.Wait();
            client = null;
        }

        public override void SendMessage(string message)
        {
            if(this.shutdown)
            {
                throw new ArgumentException("Client isn't connect!");
            }

            this.queue.Push(message);
        }

        private void Receive()
        {
            while(!this.shutdown)
            {
               var message  = this.queue.Get();

                if(message != null)
                {
                    var formatedMessage = this.FormatMessage(message.Id, message.Body);
                    this.OnNewMessage(formatedMessage);
                }

                Thread.Sleep(200);
            }
        }
    }
}
