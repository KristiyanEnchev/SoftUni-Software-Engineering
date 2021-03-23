using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicles car = CreateVeicle();
            Vehicles truck = CreateVeicle();
            Vehicles bus = CreateVeicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];
                string veicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                try
                {
                    if (veicleType == nameof(Car))
                    {
                        ProccessComand(car, command, parameter);
                    }
                    else if (veicleType == nameof(Bus))
                    {
                        ProccessComand(bus, command, parameter);
                    }
                    else
                    {
                        ProccessComand(truck, command, parameter);
                    }

                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }


        private static void ProccessComand(Vehicles veicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                try
                {
                    veicle.Drive(parameter);

                    Console.WriteLine($"{veicle.GetType().Name} travelled {parameter} km");
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "DriveEmpty")
            {
                try
                {
                    ((Bus)veicle).TurnOffAirCondition();

                    veicle.Drive(parameter);

                    ((Bus)veicle).TurnOnAirConditioner();

                    Console.WriteLine($"{veicle.GetType().Name} travelled {parameter} km");

                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                veicle.Refuel(parameter);
            }
        }
        private static Vehicles CreateVeicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuel = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            Vehicles veicle = null;

            if (type == nameof(Car))
            {
                veicle = new Car(fuel, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                veicle = new Truck(fuel, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                veicle = new Bus(fuel, fuelConsumption, tankCapacity);
            }

            return veicle;
        }
    }
}

