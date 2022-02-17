namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.Services.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IUserService UserService;

        public HomeController(IUserService userService)
        {
            UserService = userService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                object username = UserService.GetUserName(this.User.Id);

                return View(username, "/Home/IndexLoggedIn");
            }

            return View();
        }
    }
}
