namespace FastFood.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Positions;
    using System.Collections.Generic;
    using System.Linq;

    public class PositionService : IPositionService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public PositionService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Create(CreatePositionDto dto)
        {
            Position position = this.mapper.Map<Position>(dto);

            this.dbContext.Positions.Add(position);

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllPositionDto> All()
        {
            return this.dbContext.Positions
                .ProjectTo<ListAllPositionDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
