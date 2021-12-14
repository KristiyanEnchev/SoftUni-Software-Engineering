namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;
    using XmlFacade;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenre = context.Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(x => x.Purchases.Count > 0)
                    .Select(y => new
                    {
                        Id = y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = string.Join(", ", y.GameTags.Select(gt => gt.Tag.Name)),
                        Players = y.Purchases.Count,
                    })
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var serializedEmployees = JsonConvert.SerializeObject(gamesByGenre, Formatting.Indented);

            return serializedEmployees;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            PurchaseType storeTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var userPurchaseByType = context.Users.ToList()
                   .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type == storeTypeEnum)))
                   .Select(x => new ExportUserDto
                   {
                       Username = x.Username,
                       Purchases = x.Cards.SelectMany(c => c.Purchases)
                       .Where(p => p.Type == storeTypeEnum)
                       .Select(p => new ExportUserPurchaseDto
                       {
                           CardNumber = p.Card.Number,
                           CardCvc = p.Card.Cvc,
                           Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                           Game = new ExportUserPurchaseGameDto
                           {
                               Name = p.Game.Name,
                               Genre = p.Game.Genre.Name,
                               Price = p.Game.Price
                           }
                       })
                       .OrderBy(x => x.Date)
                       .ToArray(),
                       TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type == storeTypeEnum).Sum(p => p.Game.Price)),
                   })
                   .OrderByDescending(x => x.TotalSpent)
                   .ThenBy(x => x.Username)
                   .ToArray();

            var serializedEProject = XmlConverter.Serialize(userPurchaseByType, "Users");
            return serializedEProject;
        }
    }
}