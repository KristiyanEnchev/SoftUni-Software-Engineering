namespace FastFood.Core.Controllers
{
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using FastFood.Services.DTO.Employees;
    using FastFood.Services.DTO.Interfaces;
    using FastFood.Services.DTO.Items;
    using FastFood.Services.DTO.Orders;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;
    using System;
    using FastFood.Models.Enums;

    public class OrdersController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IItemService itemService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IEmployeeService employeeService, IItemService itemService, IOrderService orderService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.itemService = itemService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            ICollection<ListAllEmployeesDto> employeesN = this.employeeService.All();
            ICollection<ListAllItemsDto> itemsN = this.itemService.All();
            List<int> employees = this.employeeService.GetId();
            List<int> items = this.itemService.GetId();

            IEnumerable<OrderType> value = Enum.GetValues(typeof(OrderType)).Cast<OrderType>();

            var viewOrder = new CreateOrderViewModel
            {
                Items = items.Select(x => x).ToList(),
                Employees = employees.Select(x => x).ToList(),
                ItemsName = itemsN.Select(x => x.Name).ToList(),
                EmployeesName = employeesN.Select(x => x.Name).ToList(),
                Type = value,
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            CreateOrderDto order = this.mapper.Map<CreateOrderDto>(model);

            this.orderService.Create(order);

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            ICollection<ListAllOrdersDto> orders = this.orderService.All();

            List<OrderAllViewModel> allItemsViewModel = this.mapper
                .Map
                <ICollection<ListAllOrdersDto>, List<OrderAllViewModel>>
                (orders)
                .ToList();

            return this.View(allItemsViewModel);
        }
    }
}
