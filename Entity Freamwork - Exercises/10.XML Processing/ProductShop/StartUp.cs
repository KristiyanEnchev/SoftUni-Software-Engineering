using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var exmlData = File.ReadAllText("../../../Datasets/users.xml");
            //var res = ImportUsers(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/products.xml");
            //var res = ImportProducts(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/categories.xml");
            //var res = ImportCategories(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var res = ImportCategoryProducts(dbContext, exmlData);

            //var result = GetProductsInRange(dbContext);
            //File.WriteAllText("../../../Datasets/products-in-range.xml", result);

            //var result = GetSoldProducts(dbContext);
            //File.WriteAllText("../../../Datasets/users-sold-products.xml", result);

            //var result = GetCategoriesByProductsCount(dbContext);
            //File.WriteAllText("../../../Datasets/categories-by-products.xml", result);

            //var result = GetUsersWithProducts(dbContext);
            //File.WriteAllText("../../../Datasets/users-and-products.xml", result);

            //Console.WriteLine(res);
        }

        public static void InicializeAutoMapper()
        {
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = configMapper.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InicializeAutoMapper();
            const string root = "Users";
            var usersDto = XmlConverter.Deserializer<UserInputModel>(inputXml, root);

            List<User> users = mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InicializeAutoMapper();
            const string root = "Categories";
            var categoryDto = XmlConverter.Deserializer<CategorieInputModel>(inputXml, root);

            List<Category> categories = mapper.Map<List<Category>>(categoryDto).Where(x => x.Name != null).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InicializeAutoMapper();
            const string root = "Products";
            var productDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);

            List<Product> products = mapper.Map<List<Product>>(productDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InicializeAutoMapper();
            const string root = "CategoryProducts";
            var categoryProductsDto = XmlConverter.Deserializer<CategorieProductInputModel>(inputXml, root);

            List<CategoryProduct> products = mapper.Map<List<CategoryProduct>>(categoryProductsDto)
                .Where(x => context.Categories.Any(i => i.Id == x.CategoryId) &&
                context.Products.Any(s => s.Id == x.ProductId)).ToList();

            context.CategoryProducts.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var productsInRangeDto = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductsInRange
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            var Xml = XmlConverter.Serialize(productsInRangeDto, root);

            return Xml;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";

            var soldProductsDto = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new ExportSoldProducts
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(y => new ExportProductItemSold
                    {
                        Name = y.Name,
                        Price = y.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();


            var Xml = XmlConverter.Serialize(soldProductsDto, root);

            return Xml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";

            var categoryByProductCountDto = context.Categories
                .Select(x => new ExportCategoriesByProductCount
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var Xml = XmlConverter.Serialize(categoryByProductCountDto, root);

            return Xml;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string root = "Users";

            var userWithProductsDto = new ExportsUsersWithProducts()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Select(x => new ListOfUsers()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ProductsSold()
                    {
                        Count = x.ProductsSold.Count(ps => ps.Buyer != null),
                        Products = x.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(y => new ExportProductItemSold
                            {
                                Name = y.Name,
                                Price = y.Price
                            })
                            .OrderByDescending(x => x.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray()
            };

            var Xml = XmlConverter.Serialize(userWithProductsDto, root);

            return Xml;
        }
    }
}
