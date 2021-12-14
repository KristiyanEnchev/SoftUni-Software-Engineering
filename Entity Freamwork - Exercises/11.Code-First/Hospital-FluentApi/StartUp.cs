using System;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase 
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext dbContext = new HospitalContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
