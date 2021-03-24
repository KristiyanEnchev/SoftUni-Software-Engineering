using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Cat("Kotka", "Hrana");
            Console.WriteLine(animal.ExplainSelf());

            animal = new Dog("Kuche", "Kucheshka hrana");
            Console.WriteLine(animal.ExplainSelf());

        }
    }
}
