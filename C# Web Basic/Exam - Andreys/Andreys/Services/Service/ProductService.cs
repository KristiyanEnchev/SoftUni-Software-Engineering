namespace Andreys.Services.Service
{
    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Data.Models.Enumeration;
    using Andreys.Services.Contracts;
    using Andreys.ViewModels.Products;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(AndreysDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<string> AddProduct(AddProductViewModel model) 
        {
            var errrorModel = Validator.ValidateModel(model);

            if (GetProductById(model.Id) != null)
            {
                errrorModel.Add("This Product Already Exists");
            }

            if (errrorModel.Count != 0)
            {
                return errrorModel.ToList();
            }
            Category category = (Category)Enum.Parse(typeof(Category), model.Category);
            Gender gender = (Gender)Enum.Parse(typeof(Gender), model.Gender);

            var newProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = category,
                Gender = gender,
                Price = model.Price,
            };

            this.Data.Products.Add(newProduct);

            this.Data.SaveChanges();

            return errrorModel.ToList();
        }

        public IEnumerable<HomeProductsViewModel> GetProducts() 
        {
            var products = this.GetAllProducts()
                .ProjectTo<HomeProductsViewModel>(this.Mapper.ConfigurationProvider);

            return products;
        }

        public ProductViewModel GetDetails(string productId)
        {
            var product = Mapper.Map<ProductViewModel>(GetProductById(productId));
            return product;
        }

        public IQueryable<Product> GetAllProducts() => this.All();
        public Product GetProductById(string Id) => this.All().Where(x => x.Id == Id).FirstOrDefault();
    }
}
