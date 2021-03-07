using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(p => p.Year).FirstOrDefault();
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(p => p.Manufacturer == manufacturer && p.Model == model);

            if (car == null)
            {
                return false;
            }

            data.Remove(car);
            return true;
        }

        public Car GetCar(string manufacturer, string model)
        {
            int index = data.FindIndex(n => (n.Manufacturer == manufacturer && n.Model == model));

            if (index >= 0)
            {
                return data[index];
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
