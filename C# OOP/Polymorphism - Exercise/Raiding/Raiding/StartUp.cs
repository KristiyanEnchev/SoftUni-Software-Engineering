using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = CreateHero(type, name);

                if ( hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossHealthPoints = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());

                bossHealthPoints -= hero.Power;
            }

            if (bossHealthPoints <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;

            if (type == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
