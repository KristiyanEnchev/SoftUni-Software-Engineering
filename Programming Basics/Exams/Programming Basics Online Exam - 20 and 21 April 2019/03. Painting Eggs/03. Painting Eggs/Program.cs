using System;
using System.Security.Cryptography;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            string eggSize = Console.ReadLine();
            string eggColor = Console.ReadLine();
            double eggCount = double.Parse(Console.ReadLine());
            double price = 0;

            if (eggSize == "Large")
            {
                switch (eggColor)
                {
                    case "Red":
                        price = 16;
                        break;
                    case "Green":
                        price = 12;
                        break;
                    case "Yellow":
                        price = 9;
                        break;
                }
            }
            else if (eggSize == "Medium")
            {
                switch (eggColor)
                {
                    case "Red":
                        price = 13;
                        break;
                    case "Green":
                        price = 9;
                        break;
                    case "Yellow":
                        price = 7;
                        break;
                }
            }
            else if (eggSize == "Small")
            {
                switch (eggColor)
                {
                    case "Red":
                        price = 9;
                        break;
                    case "Green":
                        price = 8;
                        break;
                    case "Yellow":
                        price = 5;
                        break;
                }
            }
            double total = (eggCount * price) * 0.65;
            Console.WriteLine($"{total:f2} leva.");
        }
    }
}
