using System;
using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            double hoursNeeded = double.Parse(Console.ReadLine());
            double daysNeeded = double.Parse(Console.ReadLine());
            double peopleWorkingExtraCount = double.Parse(Console.ReadLine());
            double daysLeft = daysNeeded * 0.90;
            double totalH = daysLeft * 8;
            double extraH = peopleWorkingExtraCount * (2 * daysNeeded);
            double totalWorking = Math.Floor(totalH + extraH);
            if (hoursNeeded <= totalWorking)
            {
                Console.WriteLine($"Yes!{totalWorking - hoursNeeded} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeeded - totalWorking} hours needed.");
            }

        }
    }
}
