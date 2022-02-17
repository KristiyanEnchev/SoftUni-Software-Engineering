namespace CarShop.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarShop.Data;
    using CarShop.Services.Contracts;
    
    using System.Linq;

    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected BaseService(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher)
        {
            this.Data = data;
            this.Validator = validator;
            this.PasswordHasher = passwordHasher;
        }

        protected ApplicationDbContext Data { get; }
        protected IValidatorService Validator { get; }
        protected IPasswordHasher PasswordHasher { get; }

        protected DbSet<TEntity> DbSet() => this.Data.Set<TEntity>();

        public void Add(TEntity entity) => DbSet().Add(entity);

        public IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();

        public int SaveChanges() => this.Data.SaveChanges();
    }
}
