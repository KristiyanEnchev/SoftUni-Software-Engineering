using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedforSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> mileageOfCar = new Dictionary<string, int>();
            Dictionary<string, int> fuelOfCar = new Dictionary<string, int>();

            int maxFuel = 75;


            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArg = command.Split("|");
                string carName = cmdArg[0];
                int carMileage = int.Parse(cmdArg[1]);
                int carFuel = int.Parse(cmdArg[2]);

                mileageOfCar.Add(carName, carMileage);
                fuelOfCar.Add(carName, carFuel);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] cmdArg = input.Split(" : ");
                string carName = cmdArg[1];
                int fuel;


                switch (cmdArg[0])
                {
                    case "Drive":
                        int distance = int.Parse(cmdArg[2]);
                        fuel = int.Parse(cmdArg[3]);

                        if (fuelOfCar[carName] >= fuel)
                        {
                            fuelOfCar[carName] -= fuel;
                            mileageOfCar[carName] += distance;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (mileageOfCar[carName] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {carName}!");
                            fuelOfCar.Remove(carName);
                            mileageOfCar.Remove(carName);
                        }
                        break;
                    case "Refuel":
                        fuel = int.Parse(cmdArg[2]);
                        int fuelBefore = fuelOfCar[carName];
                        if ((fuelOfCar[carName] + fuel) > maxFuel)
                        {
                            int neededFuel = maxFuel - fuelBefore;
                            Console.WriteLine($"{carName} refueled with {neededFuel} liters");

                            fuelOfCar[carName] += neededFuel;

                        }
                        else
                        {
                            fuelBefore = fuelOfCar[carName];
                            fuelOfCar[carName] += fuel;
                            Console.WriteLine($"{carName} refueled with {fuel} liters");
                        }

                        break;
                    case "Revert":
                        int kms = int.Parse(cmdArg[2]);

                        mileageOfCar[carName] -= kms;
                        if (mileageOfCar[carName] < 10000)
                        {
                            mileageOfCar[carName] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{carName} mileage decreased by {kms} kilometers");
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var car in mileageOfCar.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {fuelOfCar[car.Key]} lt.");


            }
        }
    }
}
