using System;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto
{
    public class GameInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required] 
        public string Genre { get; set; }

        public string[] Tags { get; set; }
    }
}
