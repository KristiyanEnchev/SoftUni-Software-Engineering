using System;

namespace Mid_Exam_Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityOne = int.Parse(Console.ReadLine());
            int capacityTwo = int.Parse(Console.ReadLine());
            int capacityThree = int.Parse(Console.ReadLine());

            int studentCount = int.Parse(Console.ReadLine());
            int totalCapacityForHouur = capacityOne + capacityTwo + capacityThree;
            int hourCount = 0;
            int breakTime = 0;

            while (studentCount > 0)
            {
                if (hourCount % 3 == 0 && studentCount > 0 && hourCount != 0)
                {
                    breakTime++;
                }
                hourCount++;
                studentCount -= totalCapacityForHouur;
            }

            Console.WriteLine($"Time needed: {hourCount + breakTime}h.");
        }
    }
}
