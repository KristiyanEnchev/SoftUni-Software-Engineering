using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            int ilidansHelth = int.Parse(Console.ReadLine());
            int totalPower = peopleCount * power;
            if (totalPower > ilidansHelth)
            {
                Console.WriteLine($"Illidan has been slain! You defeated him with {totalPower - ilidansHelth} points.");
            }
            else
            {
                Console.WriteLine($"You are not prepared! You need {ilidansHelth - totalPower} more points.");
            }
        }
    }
}
