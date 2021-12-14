namespace FastFood.Core.MappingConfiguration
{
    using System;
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;
    using FastFood.Services.DTO.Categories;
    using FastFood.Services.DTO.Employees;
    using FastFood.Services.DTO.Items;
    using FastFood.Services.DTO.Orders;
    using FastFood.Services.DTO.Positions;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionDto, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, ListAllPositionDto>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, ListAllPositionDto>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreatePositionInputModel, CreatePositionDto>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<ListAllPositionDto, PositionsAllViewModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.PositionName));

            //Category
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>();

            this.CreateMap<CreateCategoryDto, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<ListAllCategoryDto, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));


            this.CreateMap<Category, ListAllCategoryDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            //Employees
            this.CreateMap<RegisterEmployeeInputModel, CreateEmployeeDto>();

            this.CreateMap<CreateEmployeeDto, Employee>();

            this.CreateMap<ListAllEmployeesDto, EmployeesAllViewModel>();

            this.CreateMap<EmployeesAllViewModel, ListAllEmployeesDto>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Employee, ListAllEmployeesDto>();

            this.CreateMap<ListAllPositionDto, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.PositionId));

            //items
            this.CreateMap<Category, ListAllCategoryDto>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateItemInputModel, CreateItemsDto>();

            this.CreateMap<CreateItemsDto, Item>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.CategoryId));

            this.CreateMap<ListAllItemsDto, ItemsAllViewModels>();

            this.CreateMap<Item, ListAllItemsDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Category.Name));

            this.CreateMap<ListAllCategoryDto, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.CategoryId));

            //Orders
            this.CreateMap<ListAllItemsDto, CreateOrderViewModel>()
                .ForMember(x => x.Items, y => y.MapFrom(s => s.Name));

            this.CreateMap<ListAllEmployeesDto, CreateOrderViewModel>()
                .ForMember(x => x.Employees, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateOrderDto, Order>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(s => s.EmployeeId))
                .ForMember(x => x.Customer, y => y.MapFrom(s => s.Customer))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => DateTime.Now));

            this.CreateMap<CreateOrderInputModel, CreateOrderDto>()
                .ForMember(x => x.ItemId, y => y.MapFrom(s => s.ItemId))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(s => s.EmployeeId));

            this.CreateMap<Order, ListAllOrdersDto>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("d")));

            this.CreateMap<ListAllOrdersDto, OrderAllViewModel>();
        }
    }
}
