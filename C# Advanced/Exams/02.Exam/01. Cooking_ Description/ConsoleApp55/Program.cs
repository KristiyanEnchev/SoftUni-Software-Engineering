using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Dequeue() + ingredients.Peek();

                if (sum == 25)
                {
                    bread++;
                    ingredients.Pop();
                }
                else if (sum == 50)
                {
                    cake++;
                    ingredients.Pop();
                }
                else if (sum == 75)
                {
                    pastry++;
                    ingredients.Pop();
                }
                else if (sum == 100)
                {
                    fruitPie++;
                    ingredients.Pop();
                }
                else
                {
                    int ingrediantToIncrease = ingredients.Pop() + 3;
                    ingredients.Push(ingrediantToIncrease);
                }
            }

            if (bread > 0 && cake > 0 && fruitPie > 0 && pastry > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
