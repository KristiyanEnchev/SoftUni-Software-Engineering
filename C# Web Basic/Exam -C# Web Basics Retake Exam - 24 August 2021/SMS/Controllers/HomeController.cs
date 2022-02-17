namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts.Services;

    public class HomeController : Controller
    {
        private readonly IUserService UserService;

        public HomeController(IUserService userService)
        {
            this.UserService = userService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            if (!this.User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            var model = UserService.HomeLogedInView(this.User.Id);

            return this.View(model);
        }
    }
}