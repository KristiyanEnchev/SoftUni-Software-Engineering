namespace FootballManager.Services.Service
{
    using AutoMapper.QueryableExtensions;
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services.Contracts;
    using FootballManager.ViewModels.Players;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerService : BaseService<Player>, IPlayerService
    {
        public PlayerService(FootballManagerDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<AllPlayersViewModel> GetAllPlayersModel()
        {
            var listOfPlayers = this.GetAllPlayers()
            .ProjectTo<AllPlayersViewModel>(this.Mapper.ConfigurationProvider)
            .ToList();

            return listOfPlayers;
        }

        public List<UserCollectionViewModel> GetCollection(string userId)
        {
            var collectionModel = this.GetPlayersByUserId(userId)
                .ProjectTo<UserCollectionViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();

            return collectionModel;
        }

        public List<string> CreatePlayer(CreatePlayerViewModel model, string userId)
        {
            ICollection<string> errorsModel = this.Validator.ValidateModel(model);

            if (errorsModel.ToList().Count != 0)
            {
                return errorsModel.ToList();
            }

            if (this.PlayerAlreadyExist(model.FullName))
            {
                errorsModel.Add("Player with That Name Already Exists");
                return errorsModel.ToList();
            }

            var player = new Player
            {
                FullName = model.FullName,
                Speed = (byte)int.Parse(model.Speed),
                Endurance = (byte)int.Parse(model.Endurance),
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Position = model.Position,
            };

            this.Data.Players.Add(player);

            this.Data.SaveChanges();

            return errorsModel.ToList();
        }
        public void RemovePlayerFromColleection(string userId, string playerId)
        {
            var userCard = this.Data.UserPlayers.FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            this.Data.UserPlayers.Remove(userCard);

            this.Data.SaveChanges();
        }

        public string AddplayerToUserCollection(string userId, string playerId)
        {
            string errorsModel = string.Empty;

            if (PlayerAlreadyExistInCollection(playerId, userId))
            {
                errorsModel = "Card with That Name Already Exists";
                return errorsModel;
            }

            var usercard = new UserPlayer
            {
                UserId = userId,
                PlayerId = playerId,
            };

            this.Data.UserPlayers.Add(usercard);

            this.Data.SaveChanges();

            return errorsModel;
        }

        public IQueryable<Player> GetPlayersByUserId(string userId) => this.Data.UserPlayers.Where(x => x.UserId == userId).Select(x => x.Player);

        public IQueryable<Player> GetAllPlayers() => this.All();

        public Player GetPlayerById(string cardId) => this.Data.Players.FirstOrDefault(x => x.Id == cardId);

        public User GetUserById(string userId) => this.Data.Users.FirstOrDefault(x => x.Id == userId);

        public bool PlayerAlreadyExist(string playerName)
        {

            if (this.Data.Players.Any(x => x.FullName == playerName))
            {
                return true;
            }

            return false;
        }

        public bool PlayerAlreadyExistInCollection(string playerId, string userId)
        {

            if (this.Data.UserPlayers.Any(x => x.UserId == userId && x.PlayerId == playerId))
            {
                return true;
            }

            return false;
        }
    }
}

