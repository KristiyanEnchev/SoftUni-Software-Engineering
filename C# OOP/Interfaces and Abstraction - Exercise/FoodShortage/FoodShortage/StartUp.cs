using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    var rabel = new Rabel(name, age, group);
                    buyers.Add(name, rabel);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    var citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(name, citizen);
                }
            }


            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "End")
                {
                    break;
                }

                if (!buyers.ContainsKey(comand))
                {
                    continue;
                }

                buyers[comand].BuyFood();
            }

            int total = buyers.Values.Sum(b => b.Food);


            Console.WriteLine(total);

        }
    }
}
