namespace MovieSystem.Data.UnitsOfWork
{
    using Repositories;

    public interface IUnitOfWork
    {
        IRepository<T> Get<T>()
            where T : class;

        int SaveChanges();
    }
}
