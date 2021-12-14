using FastFood.Services.DTO.Orders;
using System.Collections.Generic;

namespace FastFood.Services.DTO.Interfaces
{
    public interface IOrderService
    {
        void Create(CreateOrderDto dto);

        ICollection<ListAllOrdersDto> All();

    }
}
