namespace FastFood.Core.ViewModels.Orders
{
    using FastFood.Models.Enums;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<int> Items { get; set; }
        public List<string> ItemsName { get; set; }

        public List<int> Employees { get; set; }

        public List<string> EmployeesName { get; set; }

        public IEnumerable<OrderType> Type { get; set; }
    }
}
