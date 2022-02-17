namespace SMS.Services.Contracts
{
    using SMS.Models.Cart;
    using System.Collections.Generic;

    public interface ICartService
    {
        List<DetailsViewModel> Details(string userId);
        void AddProductToCart(string productId, string userId);
        void BuyAllProductsFromCart(string userId);
    }
}
