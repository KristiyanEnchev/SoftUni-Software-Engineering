namespace BattleCards.Services.Service
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Services.Contracts;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    using System.Linq;

    public class CardsService : BaseService<Card>, ICardsService
    {
        public CardsService(ApplicationDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<AllCardsViewModel> GetAllCardsModel()
        {
            var listOfCards = this.GetAllCards()
                .Select(x => new AllCardsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Attack = x.Attack,
                    Health = x.Health,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Keyword = x.Keyword,
                })
                .ToList();

            return listOfCards;
        }

        public List<UserCollectionViewModel> GetCollection(string userId) 
        {
            var collectionModel = this.GetCardsByUserId(userId)
                .Select(x => new UserCollectionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Attack = x.Attack,
                    Health = x.Health,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Keyword = x.Keyword,
                })
                .ToList();

            return collectionModel;
        }

        public List<string> CreateCard(CreateCardViewModel model, string userId) 
        {
            ICollection<string> errorsModel = this.Validator.ValidateModel(model);

            if (errorsModel.ToList().Count != 0)
            {
                return errorsModel.ToList();
            }

            if (this.CardAlreadyExist(model.Name))
            {
                errorsModel.Add("Card with That Name Already Exists");
                return errorsModel.ToList();
            }

            var card = new Card
            {
                Name = model.Name,
                Attack = model.Attack,
                Health = model.Health,
                ImageUrl = model.Image,
                Description = model.Description,
                Keyword = model.Keyword,
            };

            this.Data.Cards.Add(card);

            this.Data.SaveChanges();

            return errorsModel.ToList();
        }
        public void RemoveCardFromColleection(string userId, string cardId) 
        {
            var userCard = this.Data.UserCards.FirstOrDefault(x => x.UserID == userId && x.CardId == cardId);

            this.Data.UserCards.Remove(userCard);

            this.Data.SaveChanges();
        }

        public string AddCardToUserCollection(string userId, string cardId) 
        {
            string errorsModel = string.Empty;

            if (CardAlreadyExistInCollection(cardId, userId))
            {
                errorsModel = "Card with That Name Already Exists";
                return errorsModel;
            }

            var usercard = new UserCard
            {
                UserID = userId,
                CardId = cardId,
            };

            this.Data.UserCards.Add(usercard);

            this.Data.SaveChanges();

            return errorsModel;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return this.Data.Cards.ToList();
        }

        public IEnumerable<Card> GetCardsByUserId(string userId) 
        {
            var cards = this.Data.UserCards.Where(x => x.UserID == userId).Select(x => x.Card).ToList();

            return cards.ToList();
        } 

        public Card GetCardById(string cardId, string userId)
        {
            return this.Data.Cards.FirstOrDefault(x => x.Id == cardId);
        }
        public User GetUserById(string userId) 
        {
            return this.Data.Users.FirstOrDefault(x => x.Id == userId);
        }

        public bool CardAlreadyExist(string cardName) 
        {

            if (this.Data.Cards.Any(x => x.Name == cardName)) 
            {
                return true;
            }

            return false;
        }

        public bool CardAlreadyExistInCollection(string cardId, string userId) 
        {

            if (this.Data.UserCards.Any(x => x.UserID == userId && x.CardId == cardId))
            {
                return true;
            }

            return false;
        }
    }
}
