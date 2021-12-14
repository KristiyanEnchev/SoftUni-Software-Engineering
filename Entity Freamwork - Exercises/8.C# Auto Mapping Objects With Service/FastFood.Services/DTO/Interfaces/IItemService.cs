using FastFood.Services.DTO.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.DTO.Interfaces
{
    public interface IItemService
    {
        void Create(CreateItemsDto dto);

        ICollection<ListAllItemsDto> All();

        List<int> GetId();
    }
}
