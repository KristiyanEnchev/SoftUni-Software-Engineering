namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Player;


    public class Player
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(PlayernameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(ImageUrlLenght)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(PositionMaxLenght)]
        public string Position { get; set; }


        public byte Speed { get; set; }
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();

    }
}
