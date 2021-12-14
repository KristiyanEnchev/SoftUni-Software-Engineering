using FastFood.Services.DTO.Categories;
using System.Collections.Generic;

namespace FastFood.Services.DTO.Interfaces
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDto dto);

        ICollection<ListAllCategoryDto> All();
    }
}
