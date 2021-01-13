using System;
using System.Collections.Generic;
using System.Linq;
namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> KeyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> JunkMarterials = new Dictionary<string, int>();

            KeyMaterials["shards"] = 0;
            KeyMaterials["motes"] = 0;
            KeyMaterials["fragments"] = 0;

            bool HasToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        KeyMaterials[material] += quantity;

                        if (KeyMaterials[material] >= 250)
                        {
                            KeyMaterials[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }

                            HasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!JunkMarterials.ContainsKey(material))
                        {
                            JunkMarterials.Add(material, 0);
                        }
                        JunkMarterials[material] += quantity;
                    }
                }
                if (HasToBreak)
                {
                    break;
                }
            }

            Dictionary<string, int> filtered = KeyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in filtered)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in JunkMarterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
