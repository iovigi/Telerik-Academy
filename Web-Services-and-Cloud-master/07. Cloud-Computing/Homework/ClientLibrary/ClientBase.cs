namespace ClientLibrary
{
    using System;

    public abstract class ClientBase : IClient
    {
        public event Action<string> NewMessageReceive;

        public abstract void SendMessage(string message);

        protected virtual string FormatMessage(string ip, string text)
        {
            return string.Format("{0} : {1}", ip, text);
        }

        protected virtual void OnNewMessage(string message)
        {
            if(this.NewMessageReceive != null)
            {
                this.NewMessageReceive(message);
            }
        }

        public abstract void Connect();

        public abstract void Disconnect();
    }
}
