using System;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            int movieCount = int.Parse(Console.ReadLine());
            double bestRating = double.MinValue;
            double worstRating = double.MaxValue;
            string bestMovie = "";
            string worstMovie = "";
            double averageRating = 0;
            for (int i = 1; i <= movieCount; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                averageRating += rating;
                if (rating >= bestRating)
                {
                    bestRating = rating;
                    bestMovie = movieName;
                }
                if (rating <= worstRating)
                {
                    worstRating = rating;
                    worstMovie = movieName;
                }
            }
            Console.WriteLine($"{bestMovie} is with highest rating: {bestRating:f1}");
            Console.WriteLine($"{worstMovie} is with lowest rating: {worstRating:f1}");
            Console.WriteLine($"Average rating: {averageRating / movieCount:f1}");
        }
    }
}
