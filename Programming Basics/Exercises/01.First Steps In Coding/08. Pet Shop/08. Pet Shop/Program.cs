using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int pets = int.Parse(Console.ReadLine());
            int aotherPets = int.Parse(Console.ReadLine());

            double foodPet = pets * 2.50;
            double foodPet2 = aotherPets * 4.00;
            double total = foodPet + foodPet2;

            Console.WriteLine($"{total} lv.");

        }
    }
}
