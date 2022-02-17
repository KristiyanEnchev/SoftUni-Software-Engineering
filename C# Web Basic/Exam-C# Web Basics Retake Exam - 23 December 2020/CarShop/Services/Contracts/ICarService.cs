namespace CarShop.Services.Contracts
{
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        List<CarListingViewModel> GetAllCarsForUser(string userId);
        bool UserIsmechanic(string userId);
        List<string> AddCar(AddCarListingViewModel model, string userId);
    }
}
