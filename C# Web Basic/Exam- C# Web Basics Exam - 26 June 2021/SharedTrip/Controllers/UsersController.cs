namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;
    using System.Linq;
    using static Data.DataConstants;

    public class UsersController : Controller
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public UsersController(IPasswordHasher passwordHasher, ApplicationDbContext data, IValidator validator)
        {
            this.passwordHasher = passwordHasher;
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.GeneratePassword(model.Password),
                Email = model.Email,
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel model)
        {
            var hashedPassword = this.passwordHasher.GeneratePassword(model.Password);

            var user = this.data
                .Users
                .Where(u => u.Username == model.Username)
                .FirstOrDefault();


            var modelErrors = this.validator.ValidateLoginUser(user, hashedPassword);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }
            else
            {
                var userId = user.Id;
                this.SignIn(userId);

                return Redirect("/Trips/All");
            }
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
