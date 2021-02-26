using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = GenericArrayCreator.Create(5, "pesho");

            Console.WriteLine(string.Join(",", array));
        }
    }
}
