namespace MUSACA.Services.Contracts
{
    using MUSACA.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<string> Register(RegisterFormViewModel model);

        (string userId, string error) Login(LoginForemViewModel model);

        UserProfileViewModel GetUserOrders(string userId);

        bool IsAdmin(string userId);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}
