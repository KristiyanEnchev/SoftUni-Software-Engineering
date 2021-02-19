using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string comandInput = Console.ReadLine();

            while (comandInput != "Statistics")
            {
                string[] comandData = comandInput.Split(" ");
                string vlogerName = comandData[0];
                string comand = comandData[1];

                if (comand == "joined")
                {
                    if (!app.ContainsKey(vlogerName))
                    {
                        app.Add(vlogerName, new Dictionary<string, SortedSet<string>>());
                        app[vlogerName].Add("following", new SortedSet<string>());
                        app[vlogerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (comand == "followed")
                {
                    string vlogarTwoName = comandData[2];

                    if (app.ContainsKey(vlogerName) && app.ContainsKey(vlogarTwoName) && vlogerName != vlogarTwoName)
                    {
                        app[vlogerName]["following"].Add(vlogarTwoName);
                        app[vlogarTwoName]["followers"].Add(vlogerName);
                    }
                }

                comandInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDataApp
                = app.OrderByDescending(kvp => kvp.Value["followers"].Count).ThenBy(kvp => kvp.Value["following"].Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            int counter = 0;

            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedDataApp)
            {
                int followersCount = item.Value["followers"].Count;
                int followingsCount = item.Value["following"].Count;

                Console.WriteLine($"{++counter}. {item.Key} : {followersCount} followers, {followingsCount} following");

                if (counter == 1)
                {
                    foreach (string follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }

                }
            }
        }
    }
}
