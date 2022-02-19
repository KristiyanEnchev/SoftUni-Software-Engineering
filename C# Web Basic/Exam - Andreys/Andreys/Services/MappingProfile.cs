namespace Andreys.Services
{
    using Andreys.Data.Models;
    using Andreys.ViewModels.Products;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, HomeProductsViewModel>();
            this.CreateMap<Product, ProductViewModel>();
        }
    }
}
