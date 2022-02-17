
namespace CarShop.Services.Service
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services.Contracts;
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;
    using System.Linq;

    internal class CarService : BaseService<Car>, ICarService
    {
        private readonly IUserService UserService;
        public CarService(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher, IUserService userService)
            : base(data, validator, passwordHasher)
        {
            UserService = userService;
        }

        public List<CarListingViewModel> GetAllCarsForUser(string userId)
        {
            var allCars = this.Data
                .Cars.AsQueryable();

            if (UserService.IsMechanic(userId))
            {
                allCars = allCars
                    .Where(x => x.Issues
                    .Any(x => !x.IsFixed));
            }
            else
            {
                allCars = allCars
                    .Where(x => x.OwnerId == userId);
            }

            var cars = allCars.Select(c => new CarListingViewModel
            {
                Id = c.Id,
                Model = c.Model,
                Year = c.Year,
                Image = c.PictureUrl,
                PlateNumber = c.PlateNumber,
                RemainingIssues = c.Issues.Count(x => !x.IsFixed),
                FixedIssues = c.Issues.Count(x => x.IsFixed)
            })
            .ToList();

            return cars;
        }

        public List<string> AddCar(AddCarListingViewModel model, string userId)
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (modelErrors.Count != 0)
            {
                return modelErrors.ToList();
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = userId
            };

            this.Data.Cars.Add(car);

            this.Data.SaveChanges();

            return modelErrors.ToList();
        }

        public bool UserIsmechanic(string userId) 
        {
            var isMechanic = UserService.IsMechanic(userId);

            if (isMechanic) 
            {
                return true;
            }

            return false;
        }
    }
}
