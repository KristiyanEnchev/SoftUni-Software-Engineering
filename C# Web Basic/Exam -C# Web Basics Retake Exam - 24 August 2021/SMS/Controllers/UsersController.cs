namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts.Services;
    using SMS.Models.User;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            this.UserService = userService;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var result = UserService.Register(model);

            if (result != null)
            {
                return Error(result);
            }

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel model)
        {
            var (errors, userId) = UserService.Login(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            this.SignIn(userId);

            return Redirect("/Home/IndexLoggedIn");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/Home");
        }
    }
}
