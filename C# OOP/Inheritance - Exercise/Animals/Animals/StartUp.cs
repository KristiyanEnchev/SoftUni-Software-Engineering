using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "Beast!")
                {
                    break;
                }

                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (comand == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }

                if (comand == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }

                if (comand == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }

                if (comand == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }

                if (comand == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }

            }
        }
    }
}
