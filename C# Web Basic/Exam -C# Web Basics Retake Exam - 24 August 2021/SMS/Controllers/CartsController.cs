namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Services.Contracts;

    public class CartsController : Controller
    {
        private readonly ICartService CartService;

        public CartsController(ICartService cartService)
        {
            this.CartService = cartService;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var productDetails = CartService.Details(this.User.Id);

            if (productDetails == null)
            {
                return NotFound();
            }

            return View(productDetails);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            CartService.AddProductToCart(productId, this.User.Id);

            return Redirect($"/Carts/Details");
        }

        [Authorize]
        public HttpResponse Buy()
        {
            CartService.BuyAllProductsFromCart(this.User.Id);

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
