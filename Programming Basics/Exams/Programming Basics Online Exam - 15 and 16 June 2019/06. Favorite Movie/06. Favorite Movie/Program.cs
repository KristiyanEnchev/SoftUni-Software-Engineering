using System;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int movieCount = 0;
            double bestPoints = 0;
            string nameOfTheBEstMovie = "";
            while (movie != "STOP")
            {
                movieCount++;
                int lenght = movie.Length;
                if (movieCount >= 7)
                {
                    break;
                }
                double totalCount = 0;
                for (int i = 0; i < lenght; i++)
                {
                    char leter = movie[i];
                    int leterAsInt = leter;
                    if (char.IsUpper(leter))
                    {
                        leterAsInt -= lenght;
                    }
                    if (char.IsLower(leter))
                    {
                        leterAsInt -= lenght * 2;
                    }
                    totalCount += leterAsInt;

                }
                if (totalCount > bestPoints)
                {
                    nameOfTheBEstMovie = movie;
                    bestPoints = totalCount;
                }
                movie = Console.ReadLine();
            }
            if (movieCount >= 7)
            {
                Console.WriteLine("The limit is reached.");
            }
            Console.WriteLine($"The best movie for you is {nameOfTheBEstMovie} with {bestPoints} ASCII sum.");
        }
    }
}
