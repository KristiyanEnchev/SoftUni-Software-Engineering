namespace MUSACA.Data.Models
{
    using MUSACA.Data.Models.Enumeration;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.User;

    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
