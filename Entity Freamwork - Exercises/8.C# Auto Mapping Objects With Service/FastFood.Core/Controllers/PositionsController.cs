namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Positions;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IMapper mapper;

        public PositionsController(IPositionService positionService, IMapper mapper)
        {
            this.positionService = positionService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            CreatePositionDto position = this.mapper.Map<CreatePositionDto>(model);

            this.positionService.Create(position);

            return this.RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            ICollection<ListAllPositionDto> positions = this.positionService.All();

            List<PositionsAllViewModel> allPositionViewModels = this.mapper
                .Map
                <ICollection<ListAllPositionDto>, 
                List<PositionsAllViewModel>>(positions)
                .ToList();

            return this.View(allPositionViewModels);
        }
    }
}
