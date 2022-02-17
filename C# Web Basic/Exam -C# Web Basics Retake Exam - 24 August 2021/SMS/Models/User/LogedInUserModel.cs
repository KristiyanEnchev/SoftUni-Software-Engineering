namespace SMS.Models.User
{
    using System.Collections.Generic;

    public class LogedInUserModel
    {
        public string Username { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
