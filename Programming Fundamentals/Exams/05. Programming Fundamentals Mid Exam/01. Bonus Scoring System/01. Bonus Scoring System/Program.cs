using System;

namespace Exam_prep_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentsCount = int.Parse(Console.ReadLine());
            double lecturesCount = int.Parse(Console.ReadLine());
            double initialBonus = int.Parse(Console.ReadLine());

            double best = 0;
            double bestAtt = 0;
            double total = 0;
            for (int i = 0; i < studentsCount; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                total = (attendance / lecturesCount) * (5 + initialBonus);
                if (total > best)
                {
                    best = total;
                    bestAtt = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(best)}.");
            Console.WriteLine($"The student has attended {bestAtt} lectures.");
        }
    }
}
