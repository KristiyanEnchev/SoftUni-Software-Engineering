namespace MUSACA.Services.Service
{
    using MUSACA.Data;
    using MUSACA.Data.Models;
    using MUSACA.Services.Contracts;
    using MUSACA.ViewModels.Orders;
    using MUSACA.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : BaseService<User>, IUserService
    {
        private readonly IPasswordHasher passwordHasher;
        public UserService(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher)
            : base(data, validator)
        {
            this.passwordHasher = passwordHasher;
        }

        public (string userId, string error) Login(LoginForemViewModel model)
        {
            var hashedPassword = this.passwordHasher.GeneratePassword(model.Password);
            string modelErrors = string.Empty;

            var userId = this.Data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                modelErrors = "Wrong Login Information, UserName or Password are incorect";
            }

            return (userId, modelErrors);
        }

        public List<string> Register(RegisterFormViewModel model)
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (!IsEmailAvailable(model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (!IsUsernameAvailable(model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (modelErrors.Count != 0)
            {
                return modelErrors.ToList();
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.GeneratePassword(model.Password),
                Email = model.Email,
            };

            Data.Users.Add(user);

            Data.SaveChanges();

            return modelErrors.ToList();
        }

        public UserProfileViewModel GetUserOrders(string userId) 
        {
            var userOrders = this.Data.Orders.Where(x => x.CashierId == userId);
            var username = this.Data.Users.Where(x => x.Id == userId).Select(x => x.Username).FirstOrDefault();
            var model = new UserProfileViewModel
            {
                Username = username,
                Orders = userOrders.Select(x => new OrderDetaisViewModel 
                {
                    Id = x.Id,
                    Total = x.Product.Price,
                    Chashier = x.Cashier.Username,
                }).ToList()
            };

            return model;
        }

        public bool IsEmailAvailable(string email)
        {
            if (this.Data.Users.Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameAvailable(string username)
        {
            if (this.Data.Users.Any(u => u.Username == username))
            {
                return false;
            }

            return true;
        }

        public bool IsAdmin(string userId) 
        {
            var isAdmin = this.Data.Users.Where(x => x.Id == userId).Select(x => x.Role.ToString() == "Admin").ToList();

            if (isAdmin.Any())
            {
                return true;
            }

            return false;
        }
    }
}
