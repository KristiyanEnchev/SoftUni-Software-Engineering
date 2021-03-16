using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfValueNullOfEmptyOfWhitespace(string str, string massage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(massage);
            }
        }

        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exeptionMassage)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exeptionMassage);
            }
        }

        public static void ThrowIfPlayerIsMissing(Dictionary<string, Player> players, string playerName, string exeptionMassage)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new InvalidOperationException(exeptionMassage);
            }
        }
    }
}
