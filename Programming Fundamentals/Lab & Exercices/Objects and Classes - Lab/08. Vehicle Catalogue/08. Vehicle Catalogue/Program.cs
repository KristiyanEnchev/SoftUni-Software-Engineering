using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] input = comand.Split("/");

                string type = input[0];
                string brand = input[1];
                string model = input[2];
                string somthing = input[3];


                Car car = new Car();
                Truck truck = new Truck();

                if (type == "Car")
                {
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = somthing;
                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = somthing;
                    trucks.Add(truck);
                }
                comand = Console.ReadLine();
            }
            List<Car> carr = cars.OrderBy(x => x.Brand).ToList();
            List<Truck> truckk = trucks.OrderBy(x => x.Brand).ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in carr)
                {
                    Console.WriteLine(string.Join(" ", $"{car.Brand}: {car.Model} - {car.HorsePower}hp"));
                }
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in truckk)
                {
                    Console.WriteLine(string.Join(" ", $"{truck.Brand}: {truck.Model} - {truck.Weight}kg"));
                }
            }
        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
}
