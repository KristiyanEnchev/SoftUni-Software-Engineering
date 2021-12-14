using FastFood.Services.DTO.Employees;
using System.Collections.Generic;

namespace FastFood.Services.DTO.Interfaces
{
    public interface IEmployeeService
    {
        void Create(CreateEmployeeDto dto);

        ICollection<ListAllEmployeesDto> All();

        List<int> GetId();
    }
}
