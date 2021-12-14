using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SalesContext dbcontext = new SalesContext();
            //dbcontext.database.ensuredeleted();
            //dbcontext.database.ensurecreated();

            Seeder(dbcontext);
        }

        public static void Seeder(SalesContext context)
        {
            Store store = new Store();
            store.Name = "Kaufland";
            context.Stores.Add(store);

            Product product = new Product();
            product.Name = "Krastavica";
            product.Price = 7.50m;
            product.Quantity = 10;

            Product product2 = new Product();
            product2.Name = "Domat";
            product2.Price = 8.50m;
            product2.Quantity = 1;

            Product product3 = new Product();
            product3.Name = "Zele";
            product3.Price = 2.50m;
            product3.Quantity = 2;

            context.Products.Add(product);
            context.Products.Add(product2);
            context.Products.Add(product3);

            
            Customer customer = new Customer();
            customer.Name = "Gosho";
            customer.Email = "Email";
            context.Customers.Add(customer);

            Sale sale = new Sale();
            sale.CustomerId = 0;
            sale.ProductId = 1;
            sale.StoreId = 2;
            //sale.Customer = customer;
            //sale.Product = product3;
            //sale.Store = store;

            context.Sales.Add(sale);

            context.SaveChanges();
        }
    }
}
