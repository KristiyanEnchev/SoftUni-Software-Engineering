namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(ProductNameMaxLenght)]
        public string Name { get; set; }

        [Range(typeof(decimal),"0.5", "1000")]
        public decimal Price { get; set; }


        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public string CartId { get; set; }
    }
}
