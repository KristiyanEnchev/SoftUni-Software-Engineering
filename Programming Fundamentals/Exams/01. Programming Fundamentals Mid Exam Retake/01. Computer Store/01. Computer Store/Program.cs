using System;

namespace New_Mid_Exam_Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double noTaxPrice = 0;
            double tax = 0;
            while (true)
            {
                if (comand == "special" || comand == "regular")
                {
                    break;
                }
                double price = double.Parse(comand);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    comand = Console.ReadLine();
                    continue;
                }
                noTaxPrice += price;
                tax += price * 0.20;
                comand = Console.ReadLine();
                if (comand == "special" || comand == "regular")
                {
                    break;
                }
            }
            double totalPrice = noTaxPrice + tax;

            if (comand == "special")
            {
                if (noTaxPrice > 0)
                {
                    totalPrice *= 0.90;
                }
                else
                {
                    Console.WriteLine("Invalid order!");
                    Environment.Exit(0);
                }
            }
            else if (comand == "regular")
            {
                if (noTaxPrice <= 0)
                {
                    Console.WriteLine("Invalid order!");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {noTaxPrice:f2}$");
            Console.WriteLine($"Taxes: {tax:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}
