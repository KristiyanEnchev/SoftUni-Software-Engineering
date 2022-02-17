namespace BattleCards.Services.Contracts
{
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;

    public interface ICardsService
    {
        List<AllCardsViewModel> GetAllCardsModel();
        List<UserCollectionViewModel> GetCollection(string userId);
        List<string> CreateCard(CreateCardViewModel model, string userId);
        string AddCardToUserCollection(string userId, string cardId);
        void RemoveCardFromColleection(string userId, string cardId);
    }
}
