namespace ConsoleClientWithPubNub
{
    using System;
    using ClientLibrary;
    using PubNubMessaging.Core;

    public class ClientPubNub : ClientBase
    {
        private Pubnub client;

        public override void Connect()
        {
            this.client = new Pubnub("pub-c-82c9e8b8-a790-4b5c-bcb5-b126e5fe52e2", "sub-c-c963ad5c-8d54-11e5-a558-0619f8945a4f", "sec-c-MmQ2YzZmZWItNGUyYy00ZWYyLTk2MjgtZjRjNDgxNDVmYzZi");
            this.client.Subscribe<string>("chat", this.RecieveMessage, x => { }, x => { });
        }

        public override void Disconnect()
        {
            this.client = null;
        }

        public override void SendMessage(string message)
        {
            if (this.client == null)
            {
                throw new ArgumentException("Client isn't connect!");
            }

            this.client.Publish("chat", message, x => { }, x => { });
        }

        private void RecieveMessage(string message)
        {
            var messageItems = message.Split('"');

            var formatedMessage = this.FormatMessage(messageItems[3], messageItems[1]);
            this.OnNewMessage(formatedMessage);
        }
    }
}
