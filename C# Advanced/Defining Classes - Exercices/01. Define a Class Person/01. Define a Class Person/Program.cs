using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personeOne = new Person();
            personeOne.Name = "Peter";
            personeOne.Age = 20;

            Person personTwo = new Person()
            {
                Name = "Kris",
                Age = 22
            };
        }
    }
}
