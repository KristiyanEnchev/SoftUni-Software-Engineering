using System;

namespace Mid_ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            double cost = double.Parse(Console.ReadLine());
            int mounthsCount = int.Parse(Console.ReadLine());

            double currentMoney = 0;

            for (int i = 1; i <= mounthsCount; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    currentMoney *= 0.84;
                }
                if (i % 4 == 0)
                {
                    currentMoney += currentMoney * 0.25;
                }
                currentMoney += cost * 0.25;
            }
            if (currentMoney >= cost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {currentMoney - cost:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {cost - currentMoney:f2}lv. more.");
            }
        }
    }
}
