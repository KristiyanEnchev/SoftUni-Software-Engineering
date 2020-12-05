using System;
class Program
{
    static void Main(string[] args)
    {
        string city = Console.ReadLine();
        double money = double.Parse(Console.ReadLine());
        double comision = 0;
        if (money >= 0 && money <= 500)
        {
            switch (city)
            {
                case "Sofia":
                    comision = money * 0.05;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Varna":
                    comision = money * 0.045;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Plovdiv":
                    comision = money * 0.055;
                    Console.WriteLine($"{comision:f2}");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else if (money > 500 && money <= 1000)
        {
            switch (city)
            {
                case "Sofia":
                    comision = money * 0.07;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Varna":
                    comision = money * 0.075;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Plovdiv":
                    comision = money * 0.08;
                    Console.WriteLine($"{comision:f2}");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else if (money > 1000 && money <= 10000)
        {
            switch (city)
            {
                case "Sofia":
                    comision = money * 0.08;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Varna":
                    comision = money * 0.10;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Plovdiv":
                    comision = money * 0.12;
                    Console.WriteLine($"{comision:f2}");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else if (money > 10000)
        {
            switch (city)
            {
                case "Sofia":
                    comision = money * 0.12;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Varna":
                    comision = money * 0.13;
                    Console.WriteLine($"{comision:f2}");
                    break;
                case "Plovdiv":
                    comision = money * 0.145;
                    Console.WriteLine($"{comision:f2}");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}
