using System;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string objectType = Console.ReadLine();
            double russ = 0;
            double bul = 0;
            double italy = 0;
            string winner = "";
            double winnerPoint = 0;
            if (country == "Russia")
            {
                double diff = 0;
                double functionality = 0;
                switch (objectType)
                {
                    case "ribbon":
                        diff = 9.100;
                        functionality = 9.400;
                        break;
                    case "hoop":
                        diff = 9.300;
                        functionality = 9.800;
                        break;
                    case "rope":
                        diff = 9.600;
                        functionality = 9.000;
                        break;
                }
                russ = diff + functionality;
            }
            else if (country == "Bulgaria")
            {
                double diff = 0;
                double functionality = 0;
                switch (objectType)
                {
                    case "ribbon":
                        diff = 9.600;
                        functionality = 9.400;
                        break;
                    case "hoop":
                        diff = 9.550;
                        functionality = 9.750;
                        break;
                    case "rope":
                        diff = 9.500;
                        functionality = 9.400;
                        break;
                }
                bul = diff + functionality;
            }
            else if (country == "Italy")
            {
                double diff = 0;
                double functionality = 0;
                switch (objectType)
                {
                    case "ribbon":
                        diff = 9.200;
                        functionality = 9.500;
                        break;
                    case "hoop":
                        diff = 9.450;
                        functionality = 9.350;
                        break;
                    case "rope":
                        diff = 9.700;
                        functionality = 9.150;
                        break;
                }
                italy = diff + functionality;
            }
            if (bul > russ && bul > italy)
            {
                winner = "Bulgaria";
                winnerPoint = bul;
            }
            else if (russ > bul && russ > italy)
            {
                winner = "Russia";
                winnerPoint = russ;
            }
            else if (italy > bul && italy > russ)
            {
                winner = "Italy";
                winnerPoint = italy;
            }
            Console.WriteLine($"The team of {winner} get {winnerPoint:F3} on {objectType}.");
            double procent = (20 - winnerPoint) / 20;
            Console.WriteLine($"{procent * 100:f2}%");
        }
    }
}
