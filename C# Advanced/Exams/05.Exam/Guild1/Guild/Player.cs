using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public  class Player
    {
        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trail";
            Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Player {Name}: {Class}{Environment.NewLine}Rank: { Rank}{Environment.NewLine}Description: {Description}";
        }
    }
}
