using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double peopleForMusala = 0;
            double peopleForMonblan = 0;
            double peopleForKilimandjaro = 0;
            double peopleForK2 = 0;
            double peopleForEverest = 0;
            double totalPeople = 0;
            for (int i = 1; i <= groups; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                totalPeople += peopleCount;
                if (peopleCount <= 5)
                {
                    peopleForMusala += peopleCount;
                }
                else if (peopleCount > 5 && peopleCount <= 12)
                {
                    peopleForMonblan += peopleCount;
                }
                else if (peopleCount > 12 && peopleCount <= 25)
                {
                    peopleForKilimandjaro += peopleCount;
                }
                else if (peopleCount > 25 && peopleCount <= 40)
                {
                    peopleForK2 += peopleCount;
                }
                else if (peopleCount > 40)
                {
                    peopleForEverest += peopleCount;
                }
            }

            double procentMusala = peopleForMusala / totalPeople * 100;
            double procentMonblan = peopleForMonblan / totalPeople * 100;
            double procentKilimandjaro = peopleForKilimandjaro / totalPeople * 100;
            double procentK2 = peopleForK2 / totalPeople * 100;
            double procentEverest = peopleForEverest / totalPeople * 100;

            Console.WriteLine($"{procentMusala:f2}%");
            Console.WriteLine($"{procentMonblan:f2}%");
            Console.WriteLine($"{procentKilimandjaro:f2}%");
            Console.WriteLine($"{procentK2:f2}%");
            Console.WriteLine($"{procentEverest:f2}%");
        }
    }
}