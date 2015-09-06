namespace LazyInitialization
{
    using System.Threading;

    public class DatabaseConnection
    {
        private bool isInit;

        public DatabaseConnection()
        {
            this.isInit = false;
        }

        public void SendData(byte[] buffer)
        {
            if(!this.isInit)
            {
                this.Init();
            }
        }

        private void Init()
        {
            Thread.Sleep(5000);

            this.isInit = true;
        }
    }
}
