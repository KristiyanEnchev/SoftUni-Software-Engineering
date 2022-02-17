namespace SMS.Services
{
    using SMS.Contracts.Services;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Models.Product;
    using SMS.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(SMSDbContext data, IValidator validator, IPasswordHasher passwordHasher) 
            : base(data, validator, passwordHasher)
        {
        }

        public List<string> CreateProduct(CreateProductViewModel model) 
        {
            var modelErrors = this.Validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                return modelErrors.ToList();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            Data.Products.Add(product);

            Data.SaveChanges();

            return modelErrors.ToList();
        }
    }
}
