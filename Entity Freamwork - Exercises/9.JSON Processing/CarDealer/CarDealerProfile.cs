using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CarsInputModel, Car>();
            this.CreateMap<CustomersInputModel, Customer>();
            this.CreateMap<PartsInputModel, Part>();
            this.CreateMap<SalesInputModel, Sale>();
            this.CreateMap<SuppliersInputModel, Supplier>();
        }
    }
}
