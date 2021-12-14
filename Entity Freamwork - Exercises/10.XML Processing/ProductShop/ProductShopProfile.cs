using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategorieInputModel, Category>();
            this.CreateMap<CategorieProductInputModel, CategoryProduct>();
            this.CreateMap<Product, ExportProductsInRange>();
        }
    }
}
