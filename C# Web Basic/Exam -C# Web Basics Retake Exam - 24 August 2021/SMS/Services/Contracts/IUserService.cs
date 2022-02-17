namespace SMS.Contracts.Services
{
    using SMS.Models.Cart;
    using SMS.Models.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<string> Register(RegisterUserFormModel model);
        (List<string>, string) Login(LoginFormViewModel model);
        LogedInUserModel HomeLogedInView(string userId);

    }
}
