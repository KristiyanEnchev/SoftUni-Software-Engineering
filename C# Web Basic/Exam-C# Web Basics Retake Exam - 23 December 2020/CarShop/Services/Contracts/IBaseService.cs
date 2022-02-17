namespace CarShop.Services.Contracts
{
    using System.Linq;

    internal interface IBaseService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> AllAsNoTracking();
        void Add(TEntity entity);
        int SaveChanges();
    }
}
