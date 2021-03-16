using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValueNullOfEmptyOfWhitespace(value, "A name should not be empty.");

                this.name = value;

            }
        }

        public double CalculateRating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                //double allPlayersRating = 0;

                //foreach (var player in players)
                //{
                //    allPlayersRating += player.Value.CalculateAvarageStats();
                //}

                //double rating = allPlayersRating / players.Count;

                //return Math.Round(rating);

                return Math.Round(this.players.Values.Average(p => p.CalculateAvarageStats));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player.Name, player);
        }

        public void RemovePlayer(string playerName)
        {
            Validator.ThrowIfPlayerIsMissing(this.players, playerName, $"Player {playerName} is not in {this.Name} team.");

            this.players.Remove(playerName);
        }
    }
}
