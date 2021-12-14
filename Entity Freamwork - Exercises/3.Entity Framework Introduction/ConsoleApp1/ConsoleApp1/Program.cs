using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var employees = await dbContext.Employees
                    .Where(e => e.Department.Name == "Engineering")
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Department = $"{e.Department.Name}"
                    })
                    .ToListAsync();

                foreach (var item in employees)
                {
                    Console.WriteLine($"{item.Name}, {item.Department}");
                }

            }
        }
    }
}
