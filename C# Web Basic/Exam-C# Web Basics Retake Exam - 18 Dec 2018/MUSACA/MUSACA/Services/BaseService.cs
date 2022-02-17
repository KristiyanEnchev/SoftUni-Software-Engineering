namespace MUSACA.Services
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using MUSACA.Data;
    using MUSACA.Services.Contracts;

    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(ApplicationDbContext data, IValidatorService validator)
        {
            this.Data = data;
            this.Validator = validator;
        }

        protected ApplicationDbContext Data { get; }
        protected IValidatorService Validator { get; }

        protected DbSet<TEntity> DbSet() => this.Data.Set<TEntity>();

        public void Add(TEntity entity) => DbSet().Add(entity);

        public IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();

        public int SaveChanges() => this.Data.SaveChanges();
    }
}
