using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal(Console.ReadLine());
            Console.WriteLine(animal.Name);
        }
    }
}
