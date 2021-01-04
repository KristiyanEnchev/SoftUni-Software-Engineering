using System;
namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pas = "";
            int count = 0;
            for (int r = user.Length - 1; r >= 0; r--)
            {
                pas += user[r];
            }
            while (true)
            {
                string pass = Console.ReadLine();
                count++;
                if (pass == pas)
                {
                    Console.WriteLine($"User {user} logged in.");
                    Environment.Exit(0);
                }
                else if (count >= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            Console.WriteLine($"User {user} blocked!");
        }
    }
}
