namespace MUSACA.Services.Contracts
{
    using System.Collections.Generic;

    public interface IOrdersService
    {
        void Create(string userId, string productId);

        void CompleteOrder(string id);

        IEnumerable<string> GetAllActiveOrdersIds(string cashierId);
    }
}
