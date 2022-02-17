namespace SMS.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using SMS.Data.Models;
    using SMS.Models.User;

    using static Data.DataConstants;
    using SMS.Models.Product;
    using SMS.Contracts.Services;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateLoginUser(User user, string password)
        {
            var errors = new List<string>();

            if (user.Username == null)
            {
                errors.Add($"Username '{user.Username}' is not valid.");
            }

            if (user.Password == null || user.Password != password)
            {
                errors.Add($"Password is not valid.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(CreateProductViewModel product) 
        {
            var errors = new List<string>();

            if (product.Name == null || product.Name.Length < ProductNameMinLenght || product.Name.Length > ProductNameMaxLenght)
            {
                errors.Add($"ProductName is not valid , the lenght shoul de beatween {ProductNameMinLenght} and {ProductNameMaxLenght}");
            }

            if (product.Price < 0.5m || product.Price > 1000m)
            {
                errors.Add($"product price is not valid, should be beatween 0.5 and 1000");
            }

            return errors;
        }
    }
}
