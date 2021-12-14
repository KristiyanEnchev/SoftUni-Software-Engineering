namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FastFood.Services.DTO.Employees;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Positions;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IPositionService positionService, IEmployeeService employeeService, IMapper mapper)
        {
            this.positionService = positionService;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            ICollection<ListAllPositionDto> positions = this.positionService.All();

            List<RegisterEmployeeViewModel> registerViewModel = this.mapper
                .Map<ICollection<ListAllPositionDto>,
                List<RegisterEmployeeViewModel>>(positions)
                .ToList();

            return this.View(registerViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Register");
            }

            CreateEmployeeDto employee = this.mapper.Map<CreateEmployeeDto>(model);

            this.employeeService.Create(employee);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllEmployeesDto> allEmployeesModel = this.employeeService.All();

            List<EmployeesAllViewModel> allEmployeesViewModels = this.mapper
                .Map
                <ICollection<ListAllEmployeesDto>,
                List<EmployeesAllViewModel>>
                (allEmployeesModel)
                .ToList();

            return this.View(allEmployeesViewModels);
        }
    }
}
