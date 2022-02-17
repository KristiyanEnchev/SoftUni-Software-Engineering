namespace IRunes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using static DataConstants.Album;

    public class Album
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(AlbumNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        public string Cover { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
