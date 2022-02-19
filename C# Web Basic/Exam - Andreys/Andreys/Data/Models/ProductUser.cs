namespace Andreys.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductUser
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
