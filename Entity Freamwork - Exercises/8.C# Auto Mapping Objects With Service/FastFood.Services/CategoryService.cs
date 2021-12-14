namespace FastFood.Services
{
    using AutoMapper;
    using FastFood.Data;
    using FastFood.Services.DTO.Categories;
    using FastFood.Services.DTO.Interfaces;
    using System.Collections.Generic;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateCategoryDto dto)
        {
            Category category = this.mapper.Map<Category>(dto);

            this.dbContext.Categories.Add(category);

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllCategoryDto> All()
        {
            return this.dbContext.Categories
                .ProjectTo<ListAllCategoryDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
