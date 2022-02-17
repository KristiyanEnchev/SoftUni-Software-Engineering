namespace SMS.Services
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Contracts.Services;
    using SMS.Data;
    using System.Linq;

    public abstract class BaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(SMSDbContext data, IValidator validator, IPasswordHasher passwordHasher)
        {
            this.Data = data;
            this.Validator = validator;
            this.PasswordHasher = passwordHasher;
        }

        protected SMSDbContext Data { get; }
        protected IValidator Validator { get; }
        protected IPasswordHasher PasswordHasher { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();
    }
}
