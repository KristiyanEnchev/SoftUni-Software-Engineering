using System;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGradesCount = int.Parse(Console.ReadLine());
            bool Enough = false;
            string name = "";
            double score = 0;
            int problemNumber = 0;
            int badGrad = 0;
            while (!Enough)
            {
                string input = Console.ReadLine();
                if (input == "Enough")
                {
                    Enough = true;
                    break;
                }
                double grade = double.Parse(Console.ReadLine());
                name = input;
                score += grade;
                problemNumber++; ;
                if (grade <= 4.00)
                {
                    badGrad++;
                    if (badGrad >= badGradesCount)
                    {
                        break;
                    }
                }
            }
            if (Enough)
            {
                double average = 1.0 * score / problemNumber;
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {problemNumber}");
                Console.WriteLine($"Last problem: {name}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGrad} poor grades.");
            }
        }
    }
}
