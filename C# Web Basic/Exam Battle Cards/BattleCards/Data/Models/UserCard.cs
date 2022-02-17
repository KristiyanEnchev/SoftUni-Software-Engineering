using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCards.Data.Models
{
    public class UserCard
    {
        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Card))]
        public string CardId { get; set; }
        public Card Card { get; set; }
    }
}