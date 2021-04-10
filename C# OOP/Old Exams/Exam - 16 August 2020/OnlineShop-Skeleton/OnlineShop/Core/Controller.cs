using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using OnlineShop.Models;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (components.Any(x => x.Id == id))
            {
                string exeption = string.Format(ExceptionMessages.ExistingComponentId);
                throw new ArgumentException(exeption);
            }

            IComponent component = null;

            if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                string exeption = string.Format(ExceptionMessages.InvalidComponentType);
                throw new ArgumentException(exeption);
            }

            components.Add(component);
            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, component.Id, computerId);
        }

        //No need to check is computer with Id exists
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                string exeption = string.Format(ExceptionMessages.ExistingComputerId);
                throw new ArgumentException(exeption);
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                string exeption = string.Format(ExceptionMessages.InvalidComputerType);
                throw new ArgumentException(exeption);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                string exeption = string.Format(ExceptionMessages.ExistingPeripheralId);
                throw new ArgumentException(exeption);
            }

            IPeripheral peripherial = null;

            if (peripheralType == "Headset")
            {
                peripherial = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripherial = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripherial = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripherial = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                string exeption = string.Format(ExceptionMessages.InvalidPeripheralType);
                throw new ArgumentException(exeption);
            }

            peripherals.Add(peripherial);

            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripherial);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, peripherial.Id, computerId);
        }

        //No need to check is computer with Id exists
        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || !computers.Any(x => x.Price < budget))
            {
                string exeption = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
                throw new ArgumentException(exeption);
            }
            computers = computers.OrderByDescending(x => x.OverallPerformance).ToList();
            IComputer buyBestItem = computers.FirstOrDefault(x => x.Price < budget);
            computers.Remove(buyBestItem);
            return buyBestItem.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computer);

            string resultString = computer.ToString();
            return resultString;

        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            string returnSting = computer.ToString();

            return returnSting;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IPeripheral peripherial = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripherial);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripherial.Id);
        }

        public void CheckIfComputerExists(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                string exeption = string.Format(ExceptionMessages.NotExistingComputerId);
                throw new ArgumentException(exeption);
            }
        }
    }
}
