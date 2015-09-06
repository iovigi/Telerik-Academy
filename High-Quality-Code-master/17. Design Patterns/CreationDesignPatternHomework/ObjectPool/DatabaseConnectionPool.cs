namespace ObjectPool
{
    using System.Collections.Generic;

    public class DatabaseConnectionPool
    {
        private readonly Queue<DatabaseConnection> unuseConnections = new Queue<DatabaseConnection>(); 

        public DatabaseConnection GetConnection()
        {
            if (this.unuseConnections.Count > 0)
            {
                return this.unuseConnections.Dequeue();
            }

            return new DatabaseConnection();
        }

        public void Release(DatabaseConnection connection)
        {
            this.unuseConnections.Enqueue(connection);
        }
    }
}
