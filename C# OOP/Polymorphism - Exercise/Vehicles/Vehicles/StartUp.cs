using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicles car = CreateVeicle();
            Vehicles truck = CreateVeicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];
                string veicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                if (command == "Drive")
                {
                    try
                    {
                        if (veicleType == nameof(Car))
                        {
                            car.Drive(parameter);
                        }
                        else
                        {
                            truck.Drive(parameter);
                        }

                        Console.WriteLine($"{veicleType} travelled {parameter} km");
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    if (veicleType == nameof(Car))
                    {
                        car.Refuel(parameter);
                    }
                    else
                    {
                        truck.Refuel(parameter);
                    } 
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicles CreateVeicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            Vehicles veicle = null;

            if (type == nameof(Car))
            {
                veicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == nameof(Truck))
            {
                veicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return veicle;
        }
    }
}
