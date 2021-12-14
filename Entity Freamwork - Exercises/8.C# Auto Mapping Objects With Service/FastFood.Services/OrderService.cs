using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Interfaces;
using FastFood.Services.DTO.Orders;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public OrderService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateOrderDto dto)
        {
            Order order = this.mapper.Map<Order>(dto);

            order.OrderItems.Add(new OrderItem { ItemId = dto.ItemId, Quantity = dto.Quantity });

            this.dbContext.Orders.Add(order);

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllOrdersDto> All()
        {
            return this.dbContext.Orders
                .ProjectTo<ListAllOrdersDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
