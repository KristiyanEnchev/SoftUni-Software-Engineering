namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Models.Product;
    using SMS.Services.Contracts;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly IProductService ProductService;

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductViewModel model)
        {
            var modelErrors = ProductService.CreateProduct(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
