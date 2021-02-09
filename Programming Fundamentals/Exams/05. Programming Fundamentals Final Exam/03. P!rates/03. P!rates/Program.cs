using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();

            string comand = Console.ReadLine();

            while (comand != "Sail")
            {
                string[] tokens = comand.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (towns.ContainsKey(town))
                {
                    towns[town]["population"] += population;
                    towns[town]["gold"] += gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, int>()
                    {
                        {"population", population },
                        {"gold", gold }
                    });

                }
                comand = Console.ReadLine();
            }

            comand = Console.ReadLine();

            while (comand != "End")
            {
                string[] tokens = comand.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Plunder")
                {
                    string town = tokens[1];
                    int population = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");

                    towns[town]["population"] -= population;
                    towns[town]["gold"] -= gold;
                    if (towns[town]["population"] <= 0 || towns[town]["gold"] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        towns.Remove(town);
                    }
                }
                else if (action == "Prosper")
                {
                    string town = tokens[1];
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[town]["gold"] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");
                    }
                }

                comand = Console.ReadLine();
            }

            if (towns.Count > 0)
            {
                towns = towns
                    .OrderByDescending(x => x.Value["gold"])
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    int population = town.Value["population"];
                    int gold = town.Value["gold"];
                    Console.WriteLine($"{town.Key} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
