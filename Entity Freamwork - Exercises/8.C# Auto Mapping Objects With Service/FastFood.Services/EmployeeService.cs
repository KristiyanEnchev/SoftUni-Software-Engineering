namespace FastFood.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Employees;
    using FastFood.Services.DTO.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateEmployeeDto dto)
        {
            Employee employee = this.mapper.Map<Employee>(dto);

            this.dbContext.Employees.Add(employee);

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllEmployeesDto> All()
        {
            return this.dbContext.Employees
                .ProjectTo<ListAllEmployeesDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public List<int> GetId()
        {
            List<int> some = this.dbContext.Employees.Select(x => x.Id).ToList();
            return some;
        }
    }
}
