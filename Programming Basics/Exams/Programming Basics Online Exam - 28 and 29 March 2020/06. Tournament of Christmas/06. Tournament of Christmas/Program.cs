using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayCount = int.Parse(Console.ReadLine());
            int totalGameWin = 0;
            int totalGameLose = 0;
            double totalMoney = 0;
            for (int i = 1; i <= dayCount; i++)
            {
                string comand = Console.ReadLine();
                int gameWin = 0;
                int gameLose = 0;
                double moneyRaised = 0;
                while (comand != "Finish")
                {
                    string gameType = comand;
                    string condition = Console.ReadLine();
                    if (condition == "win")
                    {
                        moneyRaised += 20;
                        gameWin++;
                        totalGameWin++;
                    }
                    else if (condition == "lose")
                    {
                        totalGameLose++;
                        gameLose++;
                    }
                    comand = Console.ReadLine();
                }
                if (gameWin > gameLose)
                {
                    moneyRaised += moneyRaised * 0.10;
                }
                totalMoney += moneyRaised;
                gameLose = 0;
                gameWin = 0;
                moneyRaised = 0;
            }
            if (totalGameWin > totalGameLose)
            {
                totalMoney += totalMoney * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:F2} ");
            }
        }
    }
}