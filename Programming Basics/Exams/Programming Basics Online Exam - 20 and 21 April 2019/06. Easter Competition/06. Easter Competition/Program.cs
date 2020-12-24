using System;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadCount = int.Parse(Console.ReadLine());
            double bestGrade = 0;
            string bestChefName = "";
            for (int i = 1; i <= easterBreadCount; i++)
            {
                string chefName = Console.ReadLine();
                double gradeCount = 0;
                bool stop = false;
                while (true)
                {
                    string comand = Console.ReadLine();
                    if (comand == "Stop")
                    {
                        stop = true;
                        break;
                    }
                    int grade = int.Parse(comand);
                    if (grade <= 0 || grade > 10)
                    {
                        grade = int.Parse(comand);
                        continue;
                    }
                    gradeCount += grade;

                }
                if (stop)
                {
                    Console.WriteLine($"{chefName} has {gradeCount} points.");
                }
                if (gradeCount > bestGrade)
                {
                    Console.WriteLine($"{chefName} is the new number 1!");
                    bestChefName = chefName;
                    bestGrade = gradeCount;
                }
            }
            Console.WriteLine($"{bestChefName} won competition with {bestGrade} points!");
        }
    }
}
