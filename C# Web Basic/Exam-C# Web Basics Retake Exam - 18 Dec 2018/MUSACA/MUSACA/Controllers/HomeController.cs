namespace MUSACA.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using MUSACA.Services.Contracts;
    using System.Linq;
    using MUSACA.ViewModels.Products;

    public class HomeController : Controller
    {
        private readonly IProductService productsService;

        public HomeController(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                var model = productsService.GetAllProducts(this.User.Id);

                return this.View(model, "/Home/IndexLoggedIn");
            }

            return this.View();
        }
    }
}
