namespace SharedTrip.Services
{
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UserNameMinLenght || user.Username.Length > UserNameMaxLenght)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UserNameMinLenght} and {UserNameMaxLenght} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLenght)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLenght} characters long.");
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

        public ICollection<string> ValidateTrip(AddTripFormModel trip)
        {
            var errors = new List<string>();

            trip.StartPoint.Trim();
            trip.EndPoint.Trim();
            trip.Description.Trim();
            trip.ImagePath.Trim();

            if (trip.StartPoint == null || trip.StartPoint == string.Empty)
            {
                errors.Add($"Trip StartPoint '{trip.StartPoint}' is not valid.");
            }

            if (trip.EndPoint == null || trip.EndPoint == string.Empty)
            {
                errors.Add($"Trip EndPoint '{trip.StartPoint}' is not valid.");
            }

            if (trip.ImagePath == null || trip.ImagePath == string.Empty ||!Uri.IsWellFormedUriString(trip.ImagePath, UriKind.Absolute))
            {
                errors.Add($"Image '{trip.ImagePath}' is not valid. It must be a valid URL.");
            }

            if (trip.Description == null || trip.Description == string.Empty || trip.Description.Length > DescriptionMaxLenght)
            {
                errors.Add($"Description is too long , must not be longer than '{DescriptionMaxLenght}'");
            }

            if (trip.Seats < SeatsMinCount || trip.Seats > SeatsMaxCount)
            {
                errors.Add($"Seats count is not valid , must be beatween '{SeatsMinCount} and {SeatsMaxCount}'");
            }

            if (trip.DepartureTime == null)
            {
                errors.Add($"DepartureTime not set");
            }

            var date = DateTime.Parse(trip.DepartureTime, CultureInfo.InvariantCulture);
            if (date.Date == default)
            {
                errors.Add($"Wrong format of DepartureDate, Shold be in format 'dd.MM.yyyy HH:mm'");
            }
            else if (date < DateTime.Now)
            {
                errors.Add($"DepartureTime is not valid , shoul not be before current date");
            }

            return errors;
        }
    }
}
