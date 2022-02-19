namespace Andreys.Controllers
{
    using Andreys.Services.Contracts;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IProductService ProductService;

        public HomeController(IProductService productService)
        {
            ProductService = productService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                var products = ProductService.GetProducts().ToList();
                return View("/Home/Home", products);
            }

            return View();
        }
    }
}
