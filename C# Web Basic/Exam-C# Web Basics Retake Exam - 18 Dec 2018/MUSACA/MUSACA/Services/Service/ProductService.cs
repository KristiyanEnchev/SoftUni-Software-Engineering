namespace MUSACA.Services.Service
{
    using MUSACA.Data;
    using MUSACA.Data.Models;
    using MUSACA.Services.Contracts;
    using MUSACA.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(ApplicationDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<string> CreateProduct(ProductCreateInputModel model, string id)
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (this.Data.Products.Any(r => r.Id == model.Id))
            {
                modelErrors.Add("Already Exists");

                return modelErrors.ToList();
            }

            if (modelErrors.Count != 0)
            {
                return modelErrors.ToList();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Barcode = CreateBarcode(model.Barcode),
                Picture = model.Picture,
            };

            this.Data.Products.Add(product);

            this.Data.SaveChanges();

            return modelErrors.ToList();
        }

        public AllProductsViewModel GetAllProducts(string userId)
        {
            var products = GetProducts().ToList();

            var model = this.GetProducts()
                .Select(x =>
                new ProductViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                }).ToList();

            var allProductsModel = new AllProductsViewModel
            {
                Products = model,
                Total = products.Sum(x => x.Price),
            };

            return allProductsModel;
        }

        public List<ProductAllViewModel> AllProducts() 
        {
            var products = GetProducts()
                .Select(x => new ProductAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Barcode = x.Barcode,
                    Price = x.Price,
                    Picture = x.Picture,
                })
                .ToList();

            return products;

        }

        public string GetId(ProductOrderInputModel model)
        {
            var id = this.Data.Products
                .Where(p => p.Name == model.Product)
                .Select(u => u.Id)
                .FirstOrDefault();

            return id;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.Data.Products.ToList();
        }

        public Product GetProductById(string productId)
        {
            return this.Data.Products.FirstOrDefault(x => x.Id == productId);
        }

        public bool IsAdmin(string userId)
        {
            if (this.Data.Users.FirstOrDefault(x => x.Id == userId).Role.ToString() == "Admin")
            {
                return true;
            }

            return false;
        }


        public long CreateBarcode(string input)
        {
                input = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var barcode = Regex.Replace(input, "[a-zA-Z]", string.Empty).Substring(0, 12);

                return long.Parse(barcode);

        }
    }
}
