using System;
using System.Collections.Generic;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> input = new Dictionary<string, List<double>>();

            string comand = Console.ReadLine();
            while (comand != "buy")
            {
                string[] currProduct = comand.Split();

                string name = currProduct[0];
                double price = double.Parse(currProduct[1]);
                double quantity = double.Parse(currProduct[2]);

                if (!input.ContainsKey(name))
                {
                    List<double> priceAndQuantity = new List<double> { price, quantity };
                    input.Add(name, priceAndQuantity);
                }
                else
                {
                    input[name][0] = price;
                    input[name][1] += quantity;
                }

                comand = Console.ReadLine();
            }

            foreach (var item in input)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
