namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FastFood.Services.DTO.Categories;
    using FastFood.Services.DTO.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Create");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);

            this.categoryService.Create(categoryDto);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllCategoryDto> allCategories = this.categoryService.All();

            List<CategoryAllViewModel> allcategoriesViewModel = this.mapper.Map
                <ICollection<ListAllCategoryDto>,
                List<CategoryAllViewModel>>(allCategories)
                .ToList();

            return this.View(allcategoriesViewModel);
        }
    }
}
