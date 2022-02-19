using Andreys.Services.Contracts;
using Andreys.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        public HttpResponse Register() 
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel model)
        {
            var result = UserService.CreateUser(model);

            if (result.Count != 0)
            {
                return Error(result);
            }

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() 
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginForemViewModel model)
        {
            (string userId, string error) = UserService.Login(model);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                return Error(error);
            }

            this.SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
