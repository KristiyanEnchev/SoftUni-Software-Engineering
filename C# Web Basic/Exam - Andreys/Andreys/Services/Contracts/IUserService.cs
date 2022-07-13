﻿namespace Andreys.Services.Contracts
{
    using Andreys.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<string> CreateUser(RegisterFormViewModel model);

        (string userId, string error) Login(LoginForemViewModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}