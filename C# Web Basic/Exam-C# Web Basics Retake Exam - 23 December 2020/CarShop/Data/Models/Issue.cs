namespace CarShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstrants.Issue;

    public class Issue
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; } = false;

        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
