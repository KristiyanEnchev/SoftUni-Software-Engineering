using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(Console.ReadLine());
            int hpMax = 100;
            int mpMax = 200;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string heroName = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                Hero hero = new Hero
                {
                    Name = input[0],
                    Hp = hp > hpMax ? hpMax : hp,
                    Mp = mp > mpMax ? mpMax : mp
                };

                heroes.Add(hero);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArg = command.Split(" - ");
                string cmd = cmdArg[0];
                string heroName = cmdArg[1];

                Hero hero = heroes.FirstOrDefault(h => h.Name == heroName);

                if (cmd == "CastSpell")
                {
                    int MpNeeded = int.Parse(cmdArg[2]);
                    string spellName = cmdArg[3];

                    if (hero.Mp >= MpNeeded)
                    {
                        hero.Mp -= MpNeeded;
                        Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mp} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (cmd == "TakeDamage")
                {
                    int damage = int.Parse(cmdArg[2]);
                    string attacker = cmdArg[3];

                    if (hero.Hp > damage)
                    {
                        hero.Hp -= damage;
                        Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.Hp} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                        heroes.Remove(hero);
                    }
                }
                else if (cmd == "Recharge")
                {
                    int amount = int.Parse(cmdArg[2]);

                    if (hero.Mp + amount > mpMax)
                    {
                        amount = mpMax - hero.Mp;
                        hero.Mp = mpMax;
                    }
                    else
                    {
                        hero.Mp += amount;
                    }

                    Console.WriteLine($"{hero.Name} recharged for {amount} MP!");
                }
                else if (cmd == "Heal")
                {
                    int amount = int.Parse(cmdArg[2]);

                    if (hero.Hp + amount > hpMax)
                    {
                        amount = hpMax - hero.Hp;
                        hero.Hp = hpMax;
                    }
                    else
                    {
                        hero.Hp += amount;
                    }

                    Console.WriteLine($"{hero.Name} healed for {amount} HP!");
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroes.OrderByDescending(h => h.Hp).ThenBy(n => n.Name))
            {
                Console.WriteLine(hero);
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine($"  HP: {Hp}");
            sb.AppendLine($"  MP: {Mp}");

            return sb.ToString().TrimEnd();
        }
    }
}
