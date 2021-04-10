using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count <= 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price => this.Peripherals.Sum(x => x.Price) + this.Components.Sum(x => x.Price) + base.Price;

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                string exeption = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, Id);
                throw new ArgumentException(exeption);
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                string exeption = string.Format(ExceptionMessages.ExistingPeripheral, peripherals.GetType().Name, this.GetType().Name, Id);
                throw new ArgumentException(exeption);
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(x => x.GetType().Name == componentType))
            {
                string exeption = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, Id);
                throw new ArgumentException(exeption);
            }

            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                string exeption = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, Id); ;
                throw new ArgumentException(exeption);
            }

            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            double performence = this.peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var item in components)
            {
                sb.AppendLine("  " + item.ToString());
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({performence:f2}):");

            foreach (var item in peripherals)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
