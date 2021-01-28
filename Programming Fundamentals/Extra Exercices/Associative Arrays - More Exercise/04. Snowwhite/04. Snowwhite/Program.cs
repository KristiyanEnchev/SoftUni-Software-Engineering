using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._SnowWhite
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string comand = Console.ReadLine();
            while (comand != "Once upon a time")
            {
                string[] input = comand.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = input[0];
                string dwarfHatColor = input[1];
                int dwarfPhysic = int.Parse(input[2]);

                string key = dwarfName + ":" + dwarfHatColor;

                if (!dwarfs.ContainsKey(key))
                {
                    dwarfs.Add($"{dwarfName + ":" + dwarfHatColor}", dwarfPhysic);
                }
                else
                {
                    if (dwarfs[key] < dwarfPhysic)
                    {
                        dwarfs[key] = dwarfPhysic;
                    }
                }

                comand = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs
            .OrderByDescending(x => x.Value)
            .ThenByDescending(x => dwarfs
            .Where(y => y.Key
            .Split(':')[1] == x.Key
            .Split(':')[1])
            .Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(":")[1]}) {dwarf.Key.Split(":")[0]} <-> {dwarf.Value}");
            }
        }
    }
}