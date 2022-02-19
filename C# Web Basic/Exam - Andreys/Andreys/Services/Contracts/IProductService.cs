namespace Andreys.Services.Contracts
{
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;
    public interface IProductService
    {
        IEnumerable<HomeProductsViewModel> GetProducts();
        ProductViewModel GetDetails(string productId);
        List<string> AddProduct(AddProductViewModel model);
    }
}
