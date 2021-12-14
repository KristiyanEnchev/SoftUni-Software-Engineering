using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Export;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var exmlData = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var res = ImportSuppliers(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/cars.xml");
            //var res = ImportCars(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/customers.xml");
            //var res = ImportCustomers(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/parts.xml");
            //var res = ImportParts(dbContext, exmlData);

            //var exmlData = File.ReadAllText("../../../Datasets/sales.xml");
            //var res = ImportSales(dbContext, exmlData);

            //var result = GetCarsWithDistance(dbContext);
            //File.WriteAllText("../../../Datasets/cars1.xml", result);

            //var result = GetCarsFromMakeBmw(dbContext);
            //File.WriteAllText("../../../Datasets/bmw-cars.xml", result);

            //var result = GetLocalSuppliers(dbContext);
            //File.WriteAllText("../../../Datasets/local-suppliers.xml", result);

            //var result = GetCarsWithTheirListOfParts(dbContext);
            //File.WriteAllText("../../../Datasets/cars-and-parts.xml", result);

            //var result = GetTotalSalesByCustomer(dbContext);
            //File.WriteAllText("../../../Datasets/customers-total-sales.xml", result);

            var result = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText("../../../Datasets/sales-discounts.xml", result);


            //Console.WriteLine(res);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);
            var suppliersDto = serializer.Deserialize(textRead) as SupplierInputModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartsInputModel[]), new XmlRootAttribute("Parts"));
            var textRead = new StringReader(inputXml);
            var Dto = serializer.Deserialize(textRead) as PartsInputModel[];

            List<int> allSuppliersIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = Dto
            .Where(x => allSuppliersIds.Contains(x.SupplierId))
            .Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            })
            .ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var textRead = new StringReader(inputXml);
            var Dto = serializer.Deserialize(textRead) as CarInputModel[];

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var car in Dto)
            {
                var newCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                var parts = car.CarParts
                    .Where(x => context.Parts.Any(p => p.Id == x.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var part in parts)
                {
                    PartCar partCar = new PartCar()
                    {
                        PartId = part,
                        Car = newCar
                    };

                    partCars.Add(partCar);
                }

                cars.Add(newCar);
            }

            context.PartCars.AddRange(partCars);
            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomersInputModel[]), new XmlRootAttribute("Customers"));
            var textRead = new StringReader(inputXml);
            var Dto = serializer.Deserialize(textRead) as CustomersInputModel[];

            var customers = Dto.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            })
            .ToList();

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SalesInputModel[]), new XmlRootAttribute("Sales"));
            var textRead = new StringReader(inputXml);
            var Dto = serializer.Deserialize(textRead) as SalesInputModel[];

            var sales = Dto.Select(x => new Sale
            {
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                Discount = x.Discount
            })
            .ToList();

            var carIds = context.Cars
                .Select(x => x.Id)
                .ToList();

            var finalSales = Dto.
                Where(x => carIds.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(finalSales);

            context.SaveChanges();

            return $"Successfully imported {finalSales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new ExportCarWithDistance
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCarWithDistance[]), new XmlRootAttribute("cars"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, cars, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportFromMakeBMW
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportFromMakeBMW[]), new XmlRootAttribute("cars"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, cars, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSuppliers
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportLocalSuppliers[]), new XmlRootAttribute("suppliers"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, cars, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .Select(x => new ExportCarWithParts
                {
                    Make = x.Make,
                    Model = x.Model,
                    Parts = x.PartCars.Select(s => new ExportPartCars()
                    {
                        Name = s.Part.Name,
                        Price = s.Part.Price,
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray(),
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCarWithParts[]), new XmlRootAttribute("cars"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, cars, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var carsSales = context.Customers
             .Where(x => x.Sales.Count > 0)
             .Select(x => new ExportSalaryByCustomer()
             {
                 Name = x.Name,
                 BoughtCars = x.Sales.Count,
                 SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
             })
             .OrderByDescending(x => x.SpentMoney)
             .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSalaryByCustomer[]), new XmlRootAttribute("customers"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, carsSales, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sales = context
             .Sales
             .Select(x => new ExportSalesWithAppliedDiscount()
             {
                 Car = new ExportCarSale()
                 {
                     Make = x.Car.Make,
                     Model = x.Car.Model,
                     TravelledDistance = x.Car.TravelledDistance
                 },
                 CustomerName = x.Customer.Name,
                 Discount = x.Discount,
                 Price = x.Car.PartCars.Sum(x => x.Part.Price),
                 PriceWithDiscount = x.Car.PartCars.Sum(c => c.Part.Price) - x.Car.PartCars.Sum(c => c.Part.Price) * x.Discount / 100
             })
             .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSalesWithAppliedDiscount[]), new XmlRootAttribute("sales"));
            var textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, sales, namespaces);

            return sb.ToString().Trim();
        }
    }
}