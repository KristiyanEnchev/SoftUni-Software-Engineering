namespace Guild
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Player
    {
        public Player(string name, string clas)
        {
            this.Name = name;
            this.Class = clas;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trial";

        public string Description { get; set; } = "n/a";

        public override string ToString()
        {
            return $"Player {Name}: {Class}{Environment.NewLine}Rank: { Rank}{Environment.NewLine}Description: {Description}";
        }
    }
}
