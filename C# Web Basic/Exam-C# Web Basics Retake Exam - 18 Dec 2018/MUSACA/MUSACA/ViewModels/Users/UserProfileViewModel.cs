namespace MUSACA.ViewModels.Users
{
    using MUSACA.ViewModels.Orders;
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public IEnumerable<OrderDetaisViewModel> Orders { get; set; }
    }
}
