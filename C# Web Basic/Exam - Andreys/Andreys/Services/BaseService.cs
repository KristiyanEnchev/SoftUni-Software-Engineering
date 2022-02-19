namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Services.Contracts;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(AndreysDbContext data, IValidatorService validator)
        {
            Data = data;
            Validator = validator;
            Mapper = CreateMapper();
        }

        protected IMapper Mapper { get; set; }
        protected AndreysDbContext Data { get; }
        protected IValidatorService Validator { get; }


        protected DbSet<TEntity> DbSet() => Data.Set<TEntity>();

        public void Add(TEntity entity) => DbSet().Add(entity);

        public IQueryable<TEntity> All() => Data.Set<TEntity>();

        public IQueryable<TEntity> AllAsNoTracking() => All().AsNoTracking();

        public int SaveChanges() => Data.SaveChanges();

        public IMapper CreateMapper() 
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            this.Mapper = mapperConfig.CreateMapper();

            return Mapper;
        }
    }
}
