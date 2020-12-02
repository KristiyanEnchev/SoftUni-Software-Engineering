using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double num = double.Parse(Console.ReadLine());
                Console.WriteLine($"{num * num:f3}");
            }
            else if (figure == "rectangle")
            {
                double num1 = double.Parse(Console.ReadLine());
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"{num1 * num2:f3}");
            }
            else if (figure == "circle")
            {
                double num = double.Parse(Console.ReadLine());
                Console.WriteLine($"{Math.PI * num * num:f3}");
            }
            else if (figure == "triangle")
            {
                double num1 = double.Parse(Console.ReadLine());
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(num1 / 2) * num2:f3}");
            }
        }
    }
}
