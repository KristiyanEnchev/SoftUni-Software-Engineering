using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double plasticCount = double.Parse(Console.ReadLine());
            double paintCount = double.Parse(Console.ReadLine());
            double corselinCount = double.Parse(Console.ReadLine());
            double hoursWork = double.Parse(Console.ReadLine());
            double totalPlastic = plasticCount + 2.00;
            double totalPaint = paintCount * 1.10;
            double totalMoney = totalPaint * 14.50 + totalPlastic * 1.50 + corselinCount * 5.00 + 0.40;
            double totalWorersExpense = (totalMoney * 0.30) * hoursWork;
            double totalExpenses = totalMoney + totalWorersExpense;
            Console.WriteLine($"Total expenses: {totalExpenses:f2} lv.");
        }
    }
}
