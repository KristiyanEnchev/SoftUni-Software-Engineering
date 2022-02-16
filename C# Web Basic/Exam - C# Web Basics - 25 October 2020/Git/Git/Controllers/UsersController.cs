namespace Git.Controllers
{
    using Git.Services.Contracts;
    using Git.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        public HttpResponse Register() => View();

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

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginForemViewModel model)
        {
            (string userId, string error) = UserService.Login(model);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                return Error(error);
            }

            this.SignIn(userId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
