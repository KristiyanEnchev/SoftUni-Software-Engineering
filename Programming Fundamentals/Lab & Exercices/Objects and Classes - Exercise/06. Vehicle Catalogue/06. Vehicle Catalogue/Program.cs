using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vihicle> catalogue = new List<Vihicle>();
            string comand = Console.ReadLine();


            while (comand != "End")
            {
                string[] comandArg = comand.Split();
                string type = comandArg[0].ToLower();
                string model = comandArg[1];
                string color = comandArg[2].ToLower();
                int horsePower = int.Parse(comandArg[3]);

                Vihicle currentVihcle = new Vihicle(type, model, color, horsePower);
                catalogue.Add(currentVihcle);

                comand = Console.ReadLine();
            }

            string secondComand = Console.ReadLine();

            while (secondComand != "Close the Catalogue")
            {
                string modelType = secondComand;
                Vihicle printCar = catalogue.First(x => x.Model == modelType);

                Console.WriteLine(printCar);

                secondComand = Console.ReadLine();
            }

            List<Vihicle> onlyCar = catalogue.Where(x => x.Type == "car").ToList();
            List<Vihicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            double totalCarHP = onlyCar.Sum(x => x.Horsepower);
            double totalTruckHP = onlyTrucks.Sum(x => x.Horsepower);

            double avgCarhp = 0.00;
            double avgTruckhp = 0.00;

            if (onlyCar.Count > 0)
            {
                avgCarhp = totalCarHP / onlyCar.Count;
            }
            if (onlyTrucks.Count > 0)
            {
                avgTruckhp = totalTruckHP / onlyTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarhp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckhp:f2}.");
        }
    }

    class Vihicle
    {
        public Vihicle(string type, string model, string color, int horsPower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsPower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {Horsepower}");

            return sb.ToString().TrimEnd();
        }
    }
}
