using FastFood.Services.DTO.Positions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.DTO.Interfaces
{
    public interface IPositionService
    {
        void Create(CreatePositionDto dto);

        ICollection<ListAllPositionDto> All();

    }
}
