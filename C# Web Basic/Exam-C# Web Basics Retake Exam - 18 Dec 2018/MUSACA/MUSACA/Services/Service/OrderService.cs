namespace MUSACA.Services.Service
{
    using MUSACA.Data;
    using MUSACA.Data.Models;
    using MUSACA.Data.Models.Enumeration;
    using MUSACA.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : BaseService<Order>, IOrdersService
    {
        public OrderService(ApplicationDbContext data, IValidatorService validator) 
            : base(data, validator)
        {
        }

        public void Create(string userId, string productId) 
        {
            var product = this.Data.Products.FirstOrDefault(x => x.Id == productId);

            var order = new Order
            {
                Status = OrderStatus.Active,
                CashierId = userId,
                Product = product,
                Quantity = +1, 
            };

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();
        }

        public void CompleteOrder(string id)
        {
            var order = this.Data.Orders.FirstOrDefault(o => o.Id == id);

            order.Status = OrderStatus.Completed;

            this.Data.SaveChanges();
        }

        public IEnumerable<string> GetAllActiveOrdersIds(string cashierId)
        {
            return this.Data.Orders
                .Where(o => o.CashierId == cashierId && o.Status == OrderStatus.Active)
                .Select(o => o.Id)
                .ToList();
        }
    }
}
