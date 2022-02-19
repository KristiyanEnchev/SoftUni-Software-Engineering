namespace Andreys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Andreys.Data.Models.Enumeration;

    using static DataConstants.Product;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(ProductNameMaxLenght, MinimumLength = ProductNameMinLenght, ErrorMessage = "{0} is not correct, shold be beatween {1} and {2} charecters long")]
        public string Name { get; set; }

        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [StringLength(ImageUrlMaxLenght)]
        public string ImageUrl { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public Gender Gender { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
