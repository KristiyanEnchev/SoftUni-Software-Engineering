namespace SMS.Contracts.Services
{     
    using SMS.Data.Models;
    using SMS.Models.Product;
    using SMS.Models.User;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateLoginUser(User user, string password);
        ICollection<string> ValidateProduct(CreateProductViewModel product);
    }
}
