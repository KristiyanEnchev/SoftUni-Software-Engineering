using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine($"You are {name} {lastName}, a {age}-years old person from {town}.");

        }
    }
}
