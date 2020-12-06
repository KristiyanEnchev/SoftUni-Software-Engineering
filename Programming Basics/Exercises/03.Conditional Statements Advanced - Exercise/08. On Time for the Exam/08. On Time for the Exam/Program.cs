using System;
using System.Diagnostics;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            int hExam = int.Parse(Console.ReadLine());
            int mExam = int.Parse(Console.ReadLine());
            int hArival = int.Parse(Console.ReadLine());
            int mArival = int.Parse(Console.ReadLine());

            int totalMinEx = hExam * 60 + mExam;
            int totalMinArr = hArival * 60 + mArival;
            int diffWhenEarly = totalMinEx - totalMinArr;
            int diffWhenLate = totalMinArr - totalMinEx;

            if (totalMinEx > totalMinArr)
            {
                if (diffWhenEarly <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{diffWhenEarly} minutes before the start");
                }
                else if (diffWhenEarly > 30 && diffWhenEarly < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{diffWhenEarly} minutes before the start");
                }
                else if (diffWhenEarly >= 60)
                {
                    int h = diffWhenEarly / 60;
                    int m = diffWhenEarly % 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{h}:{m:d2} hours before the start");
                }
            }
            else if (totalMinEx < totalMinArr)
            {
                if (diffWhenLate < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{diffWhenLate} minutes after the start");
                }
                else if (diffWhenLate >= 60)
                {
                    int h = diffWhenLate / 60;
                    int m = diffWhenLate % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{h}:{m:d2} hours after the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
            }
        }
    }
}
