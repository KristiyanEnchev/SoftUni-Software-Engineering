using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }


        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }


        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        [Required]
        public Store Store { get; set; }
    }
}
