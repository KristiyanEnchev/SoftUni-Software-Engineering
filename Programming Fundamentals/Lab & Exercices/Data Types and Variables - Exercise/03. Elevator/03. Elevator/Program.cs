using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNeededToBeLift = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());
            int fullCourses = peopleNeededToBeLift / capacityOfElevator;
            int peopleLeftToLift = peopleNeededToBeLift % capacityOfElevator;
            if (peopleNeededToBeLift % capacityOfElevator <= 0)
            {
                Console.WriteLine(fullCourses);
            }
            else
            {
                Console.WriteLine(fullCourses + 1);
            }
        }
    }
}
