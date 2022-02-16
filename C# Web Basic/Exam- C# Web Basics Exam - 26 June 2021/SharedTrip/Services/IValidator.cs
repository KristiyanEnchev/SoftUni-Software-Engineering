namespace SharedTrip.Services
{
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateLoginUser(User user, string password);
        ICollection<string> ValidateTrip(AddTripFormModel trip);
    }
}
