namespace CarShop.Services.Contracts
{
    using CarShop.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<string> Register(RegisterFormViewModel model);
        (string userId, string error) Login(LoginFormViewModel model);
        bool IsMechanic(string userId);
        bool OwnsCar(string userId, string carId);
    }
}
