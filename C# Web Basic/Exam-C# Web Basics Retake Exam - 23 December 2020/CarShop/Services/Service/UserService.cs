namespace CarShop.Services.Service
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services.Contracts;
    using CarShop.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher) 
            : base(data, validator, passwordHasher)
        {
        }

        public (string userId , string error) Login(LoginFormViewModel model)
        {
            var hashedPassword = this.PasswordHasher.GeneratePassword(model.Password);
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

            return (userId ,modelErrors);
        }

        public List<string> Register(RegisterFormViewModel model)
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (this.Data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.Data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Count != 0)
            {
                return modelErrors.ToList();
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.PasswordHasher.GeneratePassword(model.Password),
                Email = model.Email,
                IsMechanic = model.UserType == "Client" ? false : true,
            };

            Data.Users.Add(user);

            Data.SaveChanges();

            return modelErrors.ToList();
        }

        public bool IsMechanic(string userId)
                => this.Data
                    .Users
                    .Any(u => u.Id == userId && u.IsMechanic);

        public bool OwnsCar(string userId, string carId)
                => this.Data
                    .Cars
                    .Any(c => c.Id == carId && c.OwnerId == userId);
    }
}
