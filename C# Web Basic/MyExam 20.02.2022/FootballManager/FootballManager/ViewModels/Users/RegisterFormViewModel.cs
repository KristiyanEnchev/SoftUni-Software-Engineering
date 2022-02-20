namespace FootballManager.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.User;
    public class RegisterFormViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "Email must be valid email")]
        [RegularExpression(UserEmailRegularExpression, ErrorMessage = "Email must be valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal")]
        public string ConfirmPassword { get; set; }
    }
}
