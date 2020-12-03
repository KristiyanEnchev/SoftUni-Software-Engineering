using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minimalWage = double.Parse(Console.ReadLine());

            double social = 0;
            double excelent = 0; ;

            if (income < minimalWage)
            {
                if (grade > 4.50)
                {
                    social = minimalWage * 0.35;
                }
            }
            if (grade >= 5.50)
            {
                excelent = grade * 25;
            }
            if (social > excelent)
            {
                if (social == 0)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");
                }
            }
            else if (excelent > social)
            {
                if (excelent == 0)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (excelent == social)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excelent)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excelent)} BGN");
                }
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
