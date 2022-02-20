using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Player))]
        public string PlayerId { get; set; }
        public Player Player { get; set; }
    }
}