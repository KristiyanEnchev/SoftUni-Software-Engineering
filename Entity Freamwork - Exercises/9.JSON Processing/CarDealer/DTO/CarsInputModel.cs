using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarsInputModel
    {
        //public CarsInputModel()
        //{
        //    this.PartCars = new List<int>();
        //}

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }

        //public ICollection<PartCar> PartCars { get; set; }
        //public List<int> PartsId { get; set; }

    }
}
