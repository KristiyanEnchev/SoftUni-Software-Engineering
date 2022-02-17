namespace MUSACA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; set; }

        public ICollection<Order> Orders { get; set; }

        [ForeignKey(nameof(Cashier))]
        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
