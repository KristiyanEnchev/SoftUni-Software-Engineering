namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using System.Linq;
    using VaporStore.DataProcessor.Dto;
    using System.Globalization;
    using VaporStore.DataProcessor.Dto.Import;
    using XmlFacade;
    using VaporStore.Data.Models.Enums;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var games = JsonConvert.DeserializeObject<IEnumerable<GameInputModel>>(jsonString);

            foreach (var jsonGame in games)
            {
                if (!IsValid(jsonGame) || !jsonGame.Tags.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre) ?? new Genre { Name = jsonGame.Genre };

                var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer) ?? new Developer { Name = jsonGame.Developer };
                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(jsonGame.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                var game = new Game
                {
                    Name = jsonGame.Name,
                    Price = jsonGame.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var jsonTag in jsonGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag) ?? new Tag { Name = jsonTag };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);

                context.SaveChanges();

                sb.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var usersJson = JsonConvert.DeserializeObject<List<UserInputModel>>(jsonString);

            List<User> users = new List<User>();

            foreach (var jsonUser in usersJson)
            {
                if (!IsValid(jsonUser))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Card> cardUser = new List<Card>();

                bool areCardValid = true;

                foreach (var card in jsonUser.Cards)
                {
                    if (!IsValid(card))
                    {
                        areCardValid = false;
                        break; ;
                    }

                    object cardTypeRes;
                    bool isCardTypeValid = Enum.TryParse(typeof(CardType), card.Type, out cardTypeRes);

                    if (!isCardTypeValid)
                    {
                        areCardValid = false;
                        break;
                    }

                    var theCard = new Card
                    {
                        Number = card.Number,
                        Cvc = card.Cvc,
                        Type = (CardType)cardTypeRes,
                    };

                    cardUser.Add(theCard);
                }

                if (!areCardValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (cardUser.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = jsonUser.FullName,
                    Username = jsonUser.Username,
                    Age = jsonUser.Age,
                    Email = jsonUser.Email,
                    Cards = cardUser,
                };

                users.Add(user);

                sb.AppendLine($"Imported {jsonUser.Username} with {jsonUser.Cards.Count()} cards");
            }

            context.Users.AddRange(users);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var purcasesXml = XmlConverter.Deserializer<PurchaseInputModel>(xmlString, "Purchases");

            List<Purchase> purchases = new List<Purchase>();

            foreach (var xmlPurchase in purcasesXml)
            {
                if (!IsValid(xmlPurchase))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object purchaseTypeObj;
                bool isPurchaseTypeValid =
                    Enum.TryParse(typeof(PurchaseType), xmlPurchase.PurchaiseType, out purchaseTypeObj);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType = (PurchaseType)purchaseTypeObj;

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card);
                var game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.GameTitle);

                if (card == null || game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = xmlPurchase.Key,
                    Date = date,
                    Card = card,
                    Game = game,
                };

                purchases.Add(purchase);
                 var username = context.Users.
                    Where(x => x.Id == purchase.Card.UserId).Select(x => x.Username).FirstOrDefault();
                //sb.AppendLine($"Imported {xmlPurchase.GameTitle} for {purchase.Card.User.Username}");
                sb.AppendLine($"Imported {xmlPurchase.GameTitle} for {username}");
            }

            context.Purchases.AddRange(purchases);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}