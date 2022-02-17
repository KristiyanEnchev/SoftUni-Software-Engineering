namespace SMS.Services
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Contracts.Services;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Models.Cart;
    using SMS.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    internal class CartService : BaseService<Cart>, ICartService
    {
        public CartService(SMSDbContext data, IValidator validator, IPasswordHasher passwordHasher)
            : base(data, validator, passwordHasher)
        {
        }

        public List<DetailsViewModel> Details(string userId)
        {
            var productDetails = this.Data
                .Products
                .Where(x => x.Cart.User.Id == userId)
                .Select(x => new DetailsViewModel
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price,
                })
                .ToList();

            return productDetails;
        }

        public void AddProductToCart(string productId, string userId)
        {
            var product = Data.Products.FirstOrDefault(x => x.Id == productId);
            var user = Data.Users.FirstOrDefault(x => x.Id == userId);
            var cart = Data.Carts.FirstOrDefault(x => x.User == user);
            cart.Products.Add(product);

            Data.SaveChanges();
        }

        public void BuyAllProductsFromCart(string userId) 
        {
            var cart = this.Data
                .Carts
                .FirstOrDefault(x => x.User.Id == userId);

            cart.Products = new List<Product>();

            var products = Data.Products.Where(x => x.CartId == cart.Id);

            foreach (var product in products)
            {
                product.CartId = null;
            }

            //var user = this.Data.Users.Where(x => x.Id == userId)
            //    .Include(u => u.Cart)
            //    .ThenInclude(c => c.Products)
            //    .FirstOrDefault();

            //user.Cart.Products.Clear();

            Data.SaveChanges();
        }
    }
}
