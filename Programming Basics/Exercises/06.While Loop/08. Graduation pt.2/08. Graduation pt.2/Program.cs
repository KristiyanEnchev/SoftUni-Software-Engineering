using System;
class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int grade = 1;
        double totalCount = 0;
        int ex = 0;
        while (grade <= 12)
        {
            double num = double.Parse(Console.ReadLine());
            if (num >= 4.0)
            {
                grade += 1;
                totalCount += num;
                continue;
            }
            else
            {
                ex += 1;
                if (ex > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {grade} grade");
                    break;
                }
            }
        }
        if (ex < 1)
        {
            double average = totalCount / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");

        }
    }
}
