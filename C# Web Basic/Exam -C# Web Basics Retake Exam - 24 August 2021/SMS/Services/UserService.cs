namespace SMS.Services
{
    using SMS.Contracts.Services;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Models.User;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(SMSDbContext data, IValidator validator, IPasswordHasher passwordHasher) 
            : base(data, validator, passwordHasher)
        {
        }

        public (List<string>, string) Login(LoginFormViewModel model)
        {
            var hashedPassword = this.PasswordHasher.GeneratePassword(model.Password);

            var user = this.Data
                .Users
                .Where(u => u.Username == model.Username)
                .FirstOrDefault();

            var modelErrors = this.Validator.ValidateLoginUser(user, hashedPassword);

            return (modelErrors.ToList(), user.Id);
        }

        public List<string> Register(RegisterUserFormModel model)
        {
            var modelErrors = Validator.ValidateUser(model);

            if (this.Data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.Data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return modelErrors.ToList();
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.PasswordHasher.GeneratePassword(model.Password),
                Email = model.Email,
            };

            var cart = new Cart { Products = new List<Product>(), User = user };

            user.Cart = cart;
            user.CartId = cart.Id;

            Data.Users.Add(user);
            Data.Carts.Add(cart);

            Data.SaveChanges();

            return modelErrors.ToList();
        }

        public LogedInUserModel HomeLogedInView(string userId)
        {
            var username = Data.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Username)
                .FirstOrDefault();

            var products = Data.Products.Select(x => new ProductViewModel
            {
                ProductId = x.Id,
                ProductName = x.Name,
                ProductPrice = x.Price
            })
            .ToList();

            var model = new LogedInUserModel
            {
                Username = username,
                Products = products
            };

            return model;
        }
    }
}
