using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return false;
            }

            roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Member")
            {
                for (int i = 0; i < roster.Count; i++)
                {
                    if (roster[i] == player)
                    {
                        roster[i].Rank = "Member";
                        break;
                    }
                }
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                for (int i = 0; i < roster.Count; i++)
                {
                    if (roster[i] == player)
                    {
                        roster[i].Rank = "Trial";
                        break;
                    }
                }
            }
        }
        public Player[] KickPlayersByClass(string clas)
        {
            List<Player> players = new List<Player>();
            players = roster.Where(x => x.Class == clas).ToList();

            foreach (var player in players)
            {
                if (player.Class == clas)
                {
                    roster.Remove(player);
                }
            }

            return players.ToArray();
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
