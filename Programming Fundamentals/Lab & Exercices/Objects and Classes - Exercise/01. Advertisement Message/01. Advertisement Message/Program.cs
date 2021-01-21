using System;

namespace Object_and_Clases_Ecercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] prase = { "Excellent product."
                    , "Such a great product."
                    , "I always use that product."
                    , "Best product of its category."
                    , "Exceptional product."
                    , "I can’t live without this product." };

            string[] events = { "Now I feel good."
                    , "I have succeeded with this product."
                    , "Makes miracles. I am happy of the results!"
                    , "I cannot believe but now I feel awesome."
                    , "Try it yourself, I am very satisfied."
                    , "I feel great!" };

            string[] actors = { "Diana"
                    , "Petya"
                    , "Stella"
                    , "Elena"
                    , "Katya"
                    , "Iva"
                    , "Annie"
                    , "Eva" };

            string[] citys = { "Burgas"
                    , "Sofia"
                    , "Plovdiv"
                    , "Varna",
                "Ruse" };

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                string massege = prase[rnd.Next(0, prase.Length)];
                string place = events[rnd.Next(0, events.Length)];
                string autor = actors[rnd.Next(0, actors.Length)];
                string city = citys[rnd.Next(0, citys.Length)];

                Console.WriteLine($"{massege} {place} {autor} - {city}.");
            }
        }
    }
}
