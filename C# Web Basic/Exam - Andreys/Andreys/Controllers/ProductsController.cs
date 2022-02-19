namespace Andreys.Controllers
{
    using Andreys.Services.Contracts;
    using Andreys.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class ProductsController : Controller
    {
        private readonly IProductService ProductService;

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddProductViewModel model)
        {
            var chechForErrors = ProductService.AddProduct(model);

            if (chechForErrors.Count != 0)
            {
                return Error(chechForErrors);
            }

            return View(chechForErrors);
        }

        public HttpResponse Details (string productId) 
        {
            var productModel = ProductService.GetDetails(productId);

            return View(productModel);
        }
    }
}
