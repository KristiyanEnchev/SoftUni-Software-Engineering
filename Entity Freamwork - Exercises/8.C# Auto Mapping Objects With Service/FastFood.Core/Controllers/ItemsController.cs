namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FastFood.Services.DTO.Categories;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Items;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly ICategoryService categorySertvice;
        private readonly IItemService itemService;
        private readonly IMapper mapper;

        public ItemsController(ICategoryService categorySertvice, IItemService itemService, IMapper mapper)
        {
            this.categorySertvice = categorySertvice;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            ICollection<ListAllCategoryDto> category = this.categorySertvice.All();

            List<CreateItemViewModel> categories = this.mapper
                .Map
                <ICollection<ListAllCategoryDto>, 
                List<CreateItemViewModel>>(category)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            CreateItemsDto item = this.mapper.Map<CreateItemsDto>(model);

            this.itemService.Create(item);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllItemsDto> items = this.itemService.All();

            List<ItemsAllViewModels> allItemsViewModel = this.mapper
                .Map
                <ICollection<ListAllItemsDto>, List<ItemsAllViewModels>>
                (items)
                .ToList();

            return this.View(allItemsViewModel);
        }
    }
}
