using System;

namespace sums_prime_and_non_prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double totalgrade = 0;
            int presentationCount = 0;
            while (comand != "Finish")
            {
                string presentationName = Console.ReadLine();
                if (presentationName == "Finish")
                {
                    break;
                }
                presentationCount += 1;
                int num = int.Parse(comand);
                double midGrade = 0;
                for (int i = 0; i < num; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    midGrade += grade;
                }
                double presGrade = midGrade / num;
                Console.WriteLine($"{presentationName} - {presGrade:f2}.");
                totalgrade += presGrade;
            }
            Console.WriteLine($"Student's final assessment is {totalgrade / presentationCount:f2}.");
        }
    }
}