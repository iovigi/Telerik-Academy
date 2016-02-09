namespace MovieSystem.Data.UnitsOfWork
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Repositories;

    public class EfUnitOfWork : IUnitOfWork
    {
        private IDictionary<string, object> repos;

        public EfUnitOfWork(DbContext dbCOntext)
        {
            this.DbContext = dbCOntext;
            this.repos = new Dictionary<string, object>();
        }

        public DbContext DbContext { get; private set; }

        public IRepository<T> Get<T>() where T : class
        {
            var key = typeof(T).FullName;
            if (!this.repos.ContainsKey(key))
            {
                var repo = new EfGenericRepository<T>(this.DbContext);

                this.repos.Add(key, repo);
            }
            return (IRepository<T>)this.repos[key];
        }

        public int SaveChanges()
        {
            return this.DbContext.SaveChanges();
        }
    }
}
