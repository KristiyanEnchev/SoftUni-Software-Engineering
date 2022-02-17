namespace MUSACA.Services.Contracts
{
    using MUSACA.ViewModels.Products;
    using System.Collections.Generic;

    public interface IProductService
    {
        List<string> CreateProduct(ProductCreateInputModel model, string id);
        AllProductsViewModel GetAllProducts(string userId);

        List<ProductAllViewModel> AllProducts();
        string GetId(ProductOrderInputModel model);
    }
}
