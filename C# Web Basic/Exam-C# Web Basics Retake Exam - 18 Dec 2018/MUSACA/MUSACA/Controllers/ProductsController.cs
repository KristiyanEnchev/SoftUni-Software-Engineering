namespace MUSACA.Controllers
{
    using MUSACA.Services.Contracts;
    using MUSACA.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrdersService ordersService;

        public ProductsController(IProductService productService, IOrdersService ordersService)
        {
            this.productService = productService;
            this.ordersService = ordersService;
        }

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProductCreateInputModel model)
        {
            var checkForErrors = productService.CreateProduct(model, this.User.Id);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return this.Redirect("/Products/All");
        }

        public HttpResponse All() 
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

           var viewModel = productService.AllProducts();

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Order(ProductOrderInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var productId = this.productService.GetId(model);

            if (productId == null)
            {
                return this.Error("Product not found.");
            }

            this.ordersService.Create(this.User.Id, productId);

            return this.Redirect("/");
        }
    }
}
