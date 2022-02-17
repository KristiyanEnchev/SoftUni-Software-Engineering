namespace MUSACA.Data.Models
{
    using MUSACA.Data.Models.Enumeration;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public OrderStatus Status { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int? Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Cashier))]
        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
