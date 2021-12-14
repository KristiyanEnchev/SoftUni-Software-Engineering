using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var inportJsonSupliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //var result = ImportSuppliers(dbContext, inportJsonSupliers);


            //var inportJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            //var result1 = ImportParts(dbContext, inportJsonParts);

            //////
            //var inportJsonCar = File.ReadAllText("../../../Datasets/cars.json");
            //var result2 = ImportCars(dbContext, inportJsonCar);

            //////
            //var inportJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //var result3 = ImportCustomers(dbContext, inportJsonCustomers);

            ////
            //var inportJsonSales = File.ReadAllText("../../../Datasets/sales.json");
            //var result4 = ImportSales(dbContext, inportJsonSales);

            //var result4 = GetOrderedCustomers(dbContext);
            //File.WriteAllText("../../../Datasets/ordered-customers.json", result4);

            //var result4 = GetCarsFromMakeToyota(dbContext);
            //File.WriteAllText("../../../Datasets/toyota-cars.json", result4);

            //var result4 = GetLocalSuppliers(dbContext);
            //File.WriteAllText("../../../Datasets/local-suppliers.json", result4);

            //var result4 = GetCarsWithTheirListOfParts(dbContext);
            //File.WriteAllText("../../../Datasets/cars-and-parts.json", result4);

            //var result4 = GetTotalSalesByCustomer(dbContext);
            //File.WriteAllText("../../../Datasets/customers-total-sales.json", result4);

            //var result4 = GetSalesWithAppliedDiscount(dbContext);
            //File.WriteAllText("../../../Datasets/sales-discounts.json", result4);

            //Console.WriteLine(result2);
            //Console.WriteLine(result1.Length);
        }

        private static void InicializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {

            InicializeAutoMapper();

            var dtoSuplier = JsonConvert.DeserializeObject<IEnumerable<SuppliersInputModel>>(inputJson);

            var supliers = mapper.Map<IEnumerable<Supplier>>(dtoSuplier);

            context.Suppliers.AddRange(supliers);

            context.SaveChanges();

            return $"Successfully imported {supliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            InicializeAutoMapper();

            var supliers = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartsInputModel>>(inputJson).Where(x => supliers.Contains(x.SupplierId)).ToList();

            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarsInputModel>>(inputJson);
            var cars = new List<Car>();
            //var cars = mapper.Map<IEnumerable<Car>>(dtoCars);
            foreach (var car in dtoCars)
            {
                var automobile = mapper.Map<Car>(car);
                cars.Add(automobile);

                var partIds = car
                    .PartsId
                    .Distinct()
                    .ToList();

                foreach (var id in partIds)
                {
                    var partCar = new PartCar
                    {
                        PartId = id,
                        Car = automobile
                    };
                    automobile.PartCars.Add(partCar);
                }
            };

            context.Cars.AddRange(cars);

            context.SaveChanges();
            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {

            InicializeAutoMapper();

            var dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<CustomersInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InicializeAutoMapper();

            var dtoSales = JsonConvert.DeserializeObject<IEnumerable<SalesInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customersOrdered = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var customersJson = JsonConvert.SerializeObject(customersOrdered);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var makeToyota = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var toyotaJson = JsonConvert.SerializeObject(makeToyota);

            return toyotaJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSupplier = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                });

            var supplierJson = JsonConvert.SerializeObject(localSupplier);

            return supplierJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carListOfParts = context.Cars
                .Select(x => new
                {
                    car = new { Make = x.Make, Model = x.Model, TravelledDistance = x.TravelledDistance },
                    parts = x.PartCars
                    .Select(s => new { Name = s.Part.Name, Price = s.Part.Price.ToString("F2") })
                })
                .ToList();

            var carListJson = JsonConvert.SerializeObject(carListOfParts);

            return carListJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(s => s.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var salesJson = JsonConvert.SerializeObject(salesByCustomers);

            return salesJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new 
                    { 
                        Make = x.Car.Make, 
                        Model = x.Car.Model, 
                        TravelledDistance = x.Car.TravelledDistance 
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(y => y.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100)).ToString("F2")
                })
                .ToList();

            var nullHandler = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented
            };

            var discountedSalesJson = JsonConvert.SerializeObject(salesWithDiscount, nullHandler);

            return discountedSalesJson;
        }
    }
}