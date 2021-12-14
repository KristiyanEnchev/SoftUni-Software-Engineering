

using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using SoftUni.Models;

namespace SoftUni
{
    using System;
    using SoftUni.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            string result = RemoveTown(db);

            Console.WriteLine(result);

        }
        public static string RemoveTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .ToList();

            var employees = context.Employees
                .Where(x => x.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Address = null;
            }

            int count = addresses.Count();
            context.RemoveRange(addresses);

            var town = context.Towns
                .Where(x => x.Name == "Seattle")
                .ToList();

            context.Remove(town.First());
            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
