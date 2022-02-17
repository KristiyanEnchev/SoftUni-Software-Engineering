namespace SMS.Services.Contracts
{
    using SMS.Models.Product;
    using System.Collections.Generic;

    public interface IProductService
    {
        List<string> CreateProduct(CreateProductViewModel model);
    }
}
