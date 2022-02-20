namespace FootballManager.Services.Contracts
{
    using FootballManager.ViewModels.Players;
    using System.Collections.Generic;

    public interface IPlayerService
    {
        List<AllPlayersViewModel> GetAllPlayersModel();
        List<UserCollectionViewModel> GetCollection(string userId);
        List<string> CreatePlayer(CreatePlayerViewModel model, string userId);
        void RemovePlayerFromColleection(string userId, string playerId);
        string AddplayerToUserCollection(string userId, string cardId);
    }
}
