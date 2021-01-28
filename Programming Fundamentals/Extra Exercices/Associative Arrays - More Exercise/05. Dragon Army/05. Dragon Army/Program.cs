using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<double>>> list = new Dictionary<string, Dictionary<string, List<double>>>();

            string defaultDamege = "45";
            string defaultArmour = "10";
            string defaultHealth = "250";

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string type = input[0];
                string name = input[1];

                string damage = input[2];
                string health = input[3];
                string armor = input[4];

                if (damage == "null")
                {
                    damage = defaultDamege;
                }
                if (health == "null")
                {
                    health = defaultHealth;
                }
                if (armor == "null")
                {
                    armor = defaultArmour;
                }

                if (!list.ContainsKey(type))
                {
                    list.Add(type, new Dictionary<string, List<double>>());
                }

                if (!list[type].ContainsKey(name))
                {
                    list[type].Add(name, new List<double>());
                    list[type][name].Add(double.Parse(damage));
                    list[type][name].Add(double.Parse(health));
                    list[type][name].Add(double.Parse(armor));
                }
                else
                {
                    list[type][name].Clear();
                    list[type][name].Add(double.Parse(damage));
                    list[type][name].Add(double.Parse(health));
                    list[type][name].Add(double.Parse(armor));
                }
            }

            foreach (var item in list)
            {
                double avgDamage = 0;
                double avgArmour = 0;
                double avgHealth = 0;
                int count = 0;

                foreach (var stat in item.Value.Values)
                {
                    avgDamage += stat[0];
                    avgHealth += stat[1];
                    avgArmour += stat[2];
                    count++;
                }

                Console.WriteLine($"{item.Key}::({avgDamage / count:f2}/{avgHealth / count:f2}/{avgArmour / count:f2})");

                foreach (var dragon in item.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
