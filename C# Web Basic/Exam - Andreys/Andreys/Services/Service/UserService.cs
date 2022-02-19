namespace Andreys.Services.Service
{
    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Services;
    using Andreys.Services.Contracts;
    using Andreys.ViewModels.Users;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : BaseService<User>, IUserService
    {
        private readonly IPasswordHasher passwordHasher;

        public UserService(AndreysDbContext data, IValidatorService validator, IPasswordHasher passwordHasher)
            : base(data, validator)
        {
            this.passwordHasher = passwordHasher;
        }

        public (string userId, string error) Login(LoginForemViewModel model)
        {
            var hashedPassword = passwordHasher.GeneratePassword(model.Password);
            string modelErrors = string.Empty;

            var userId = Data
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

        public List<string> CreateUser(RegisterFormViewModel model)
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
                Password = passwordHasher.GeneratePassword(model.Password),
                Email = model.Email,
            };

            Data.Users.Add(user);

            Data.SaveChanges();

            return modelErrors.ToList();
        }

        public bool IsEmailAvailable(string email)
        {
            if (Data.Users.Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameAvailable(string username)
        {
            if (Data.Users.Any(u => u.Username == username))
            {
                return false;
            }

            return true;
        }
    }
}
