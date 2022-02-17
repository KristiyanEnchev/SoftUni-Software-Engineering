namespace IRunes.Services.Contracts
{
    using IRunes.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<string> CreateUser(RegisterFormViewModel model);

        (string userId, string error) Login(LoginFormViewModel model);

        string GetUserName(string userId);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}
