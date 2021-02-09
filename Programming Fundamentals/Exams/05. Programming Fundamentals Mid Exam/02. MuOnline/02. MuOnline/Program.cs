using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|")
                .ToList();

            int count = 0;
            int initialHelth = 100;
            int bitcoin = 0;

            for (int i = 0; i < list.Count; i++)
            {
                string[] comand = list[i].Split(" ");
                count++;
                if (comand[0] == "potion")
                {
                    int amount = int.Parse(comand[1]);
                    if (initialHelth + amount <= 100)
                    {
                        initialHelth += amount;
                        Console.WriteLine($"You healed for {amount} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - initialHelth} hp.");
                        initialHelth = 100;
                    }

                    Console.WriteLine($"Current health: {initialHelth} hp.");
                }
                else if (comand[0] == "chest")
                {
                    int bitcoinFount = int.Parse(comand[1]);
                    bitcoin += bitcoinFount;
                    Console.WriteLine($"You found {bitcoinFount} bitcoins.");
                }
                else
                {
                    int monsterAttack = int.Parse(comand[1]);
                    if (initialHelth - monsterAttack > 0)
                    {
                        Console.WriteLine($"You slayed {comand[0]}.");
                        initialHelth -= monsterAttack;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {comand[0]}.");
                        Console.WriteLine($"Best room: {count}");
                        initialHelth -= monsterAttack;
                        Environment.Exit(0);
                    }
                }
            }
            if (initialHelth > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoin}");
                Console.WriteLine($"Health: {initialHelth}");
            }
        }
    }
}
