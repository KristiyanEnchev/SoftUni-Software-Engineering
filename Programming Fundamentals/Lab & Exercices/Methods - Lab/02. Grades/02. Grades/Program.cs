using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(double.Parse(Console.ReadLine()));
        }

        static void Print(double grade)
        {
            string gradeValue = string.Empty;

            if (grade >= 2.00 && grade <= 2.99)
            {
                gradeValue = "Fail";
            }
            else if (grade >= 3.00 && grade <= 3.49)
            {
                gradeValue = "Poor";
            }
            else if (grade >= 3.50 && grade <= 4.49)
            {
                gradeValue = "Good";
            }
            else if (grade >= 4.50 && grade <= 5.49)
            {
                gradeValue = "Very good";
            }
            else if (grade >= 5.50 && grade <= 6.00)
            {
                gradeValue = "Excellent";
            }

            Console.WriteLine(gradeValue);
        }
    }
}
