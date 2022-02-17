namespace MUSACA.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Product;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public long Barcode { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}
