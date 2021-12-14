namespace FastFood.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Items;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemService : IItemService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateItemsDto dto)
        {
            Item item = this.mapper.Map<Item>(dto);

            this.dbContext.Items.Add(item);

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllItemsDto> All()
        {
            return this.dbContext.Items
                .ProjectTo<ListAllItemsDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public List<int> GetId()
        {
            return this.dbContext.Items.Select(x => x.Id).ToList();
        }
    }
}
