namespace IRunes.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants.Track;

    public class Track
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(TrackNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Album))]
        public string AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
