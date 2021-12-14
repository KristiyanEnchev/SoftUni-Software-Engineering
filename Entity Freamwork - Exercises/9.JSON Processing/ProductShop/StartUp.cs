using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Models.DTO;

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


            //
            //string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            //var resultUsers = ImportUsers(dbContext, inputJsonUsers);

            //
            //string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            //var resultProducts = ImportProducts(dbContext, inputJsonProducts);

            //
            //string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            //var resultCategories = ImportCategories(dbContext, inputJsonCategories);

            //
            //string inputJsonCategoryProduct = File.ReadAllText("../../../Datasets/categories-products.json");
            //var resultCategoryProduct = ImportCategoryProducts(dbContext, inputJsonCategoryProduct);

            //
            //var result = GetProductsInRange(dbContext);
            //File.WriteAllText("../../../Datasets/products-in-range.json", result);

            //
            var result = GetSoldProducts(dbContext);
            File.WriteAllText("../../../Datasets/users-sold-products.json", result);

            //
            //var result = GetCategoriesByProductsCount(dbContext);
            //File.WriteAllText("../../../Datasets/categories-by-products.json", result);

            //
            //var result = GetUsersWithProducts(dbContext);
            //File.WriteAllText("../../../Datasets/users-and-products.json", result);

            Console.WriteLine(result);
            Console.WriteLine(result.Length);
        }

        private static void InicializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoCategory = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null).ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategory);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoCategoryProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProduct);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .Where(x => x.price >= 500 && x.price <= 1000)
                .OrderBy(x => x.price)
                .ToList();

            var productSerialized = JsonConvert.SerializeObject(products);

            return productSerialized;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userSoldProducts = context.Users
                .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(s => s.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(v => v.BuyerId != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName
                        })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var userSoldProductsSerialized = JsonConvert.SerializeObject(userSoldProducts);

            return userSoldProductsSerialized;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = (x.CategoryProducts.Sum(p => p.Product.Price) / x.CategoryProducts.Count).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2"),
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var categoriesByProductsCountSerialized = JsonConvert.SerializeObject(categoriesByProductsCount);

            return categoriesByProductsCountSerialized;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
               .Include(x => x.ProductsSold)
               .ToList()
               .Where(x => x.ProductsSold.Any(s => s.BuyerId != null))
               .Select(x => new
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   age = x.Age,
                   soldProducts = new
                   {
                       count = x.ProductsSold.Where(s => s.BuyerId != null).Count(),
                       products = x.ProductsSold.Where(s => s.BuyerId != null)
                           .Select(a => new
                           {
                               name = a.Name,
                               price = a.Price
                           })
                   }
               })
               .OrderByDescending(x => x.soldProducts.products.Count())
               .ToList();

            var resultObject = new
            {
                usersCount = usersWithProducts.Count(),
                users = usersWithProducts,
            };

            var jsonSerializeSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var usersWithProductsSerialized = JsonConvert.SerializeObject(resultObject, jsonSerializeSettings);

            return usersWithProductsSerialized;

        }
    }
}