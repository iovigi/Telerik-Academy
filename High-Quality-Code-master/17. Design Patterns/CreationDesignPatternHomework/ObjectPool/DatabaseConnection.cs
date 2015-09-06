namespace ObjectPool
{
    using System;

    public class DatabaseConnection:IDisposable
    {
        public DatabaseConnection()
        {
        }

        public DatabaseConnectionPool DatabaseConnectionPool
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void Dispose()
        {
            //clear connection
        }
    }
}
