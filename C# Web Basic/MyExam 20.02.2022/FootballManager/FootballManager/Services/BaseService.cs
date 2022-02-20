namespace FootballManager.Services
{
    using AutoMapper;
    using FootballManager.Data;
    using FootballManager.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(FootballManagerDbContext data, IValidatorService validator)
        {
            Data = data;
            Validator = validator;
            Mapper = CreateMapper();
        }

        protected IMapper Mapper { get; set; }
        protected FootballManagerDbContext Data { get; }
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

            Mapper = mapperConfig.CreateMapper();

            return Mapper;
        }
    }
}
