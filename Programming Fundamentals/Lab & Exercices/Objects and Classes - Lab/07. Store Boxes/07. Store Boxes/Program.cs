using System;
using System.Collections.Generic;
using System.Linq;

namespace _06
{
    class Item
    {
        public static string Name { get; set; }
        public static decimal Price { get; set; }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public string Itemmm { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            List<Box> boxes = new List<Box>();
            while (comand != "end")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string serialNumber = input[0];
                string item = input[1];
                int itemQuantity = int.Parse(input[2]);
                decimal priceForABox = decimal.Parse(input[3]);

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.ItemQuantity = itemQuantity;
                box.PriceForABox = priceForABox;
                Item.Name = item;
                Item.Price = priceForABox * itemQuantity;
                box.Itemmm = item;

                boxes.Add(box);

                comand = Console.ReadLine();
            }
            List<Box> sorted = boxes.OrderBy(boxess => boxess.PriceForABox * boxess.ItemQuantity).ToList();
            sorted.Reverse();

            foreach (Box box in sorted)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Itemmm} - ${box.PriceForABox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox * box.ItemQuantity:F2}");
            }
        }
    }
}
