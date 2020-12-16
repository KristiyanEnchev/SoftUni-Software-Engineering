using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            double totalGrade = 0;
            double top = 0;
            double mid = 0;
            double floor = 0;
            double fail = 0;
            for (int i = 1; i <= studentCount; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                totalGrade += grade;
                if (grade >= 2.00 && grade <= 2.99)
                {
                    fail++;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    floor++;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    mid++;
                }
                else if (grade >= 5.00)
                {
                    top++;
                }
            }
            Console.WriteLine($"Top students: {top / studentCount * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {mid / studentCount * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {floor / studentCount * 100:f2}%");
            Console.WriteLine($"Fail: {fail / studentCount * 100:f2}%");
            Console.WriteLine($"Average: {totalGrade / studentCount:f2}");
        }
    }
}
