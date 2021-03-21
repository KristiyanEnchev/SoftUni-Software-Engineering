using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammal;
using WildFarm.Animals.Mammal.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] animalParts = line.Split();

                Animal anima = CreateAnimal(animalParts);

                animals.Add(anima);

                string[] foodParts = Console.ReadLine().Split();

                Food food = CreateFood(foodParts);

                Console.WriteLine(anima.ProduceSound());

                try
                {
                    anima.Eat(food);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        private static Food CreateFood(string[] foodParts)
        {
            string type = foodParts[0];
            int quantity = int.Parse(foodParts[1]);

            Food food = null;

            if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }
        private static Animal CreateAnimal(string[] parts)
        {
            string type = parts[0];
            Animal animal = null;

            string name = parts[1];
            double weigth = double.Parse(parts[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Hen(name, weigth, wingSize);

            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Owl(name, weigth, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingregion = parts[3];
                animal = new Mouse(name, weigth, livingregion);
            }
            else if (type == nameof(Dog))
            {
                string livingregion = parts[3];
                animal = new Dog(name, weigth, livingregion);
            }
            else if (type == nameof(Cat))
            {
                string livingregion = parts[3];
                string breed = parts[4];
                animal = new Cat(name, weigth, livingregion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingregion = parts[3];
                string breed = parts[4];
                animal = new Tiger(name, weigth, livingregion, breed);
            }

            return animal;
        }
    }
}
