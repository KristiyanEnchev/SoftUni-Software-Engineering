namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;
    using XmlFacade;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var topTheaters = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(y => y.RowNumber >= 1 && y.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets.Where(p => p.RowNumber >= 1 && p.RowNumber <= 5).Select(s => new
                    {
                        Price = s.Price,
                        RowNumber = s.RowNumber,
                    })
                    .OrderByDescending(x => x.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            var serialized = JsonConvert.SerializeObject(topTheaters, Formatting.Indented);

            return serialized;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    //Rating = x.Rating == 0 ? "Premier" : $"{x.Rating}",
                    Rating = x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(s => s.IsMainCharacter == true)
                    .Select(x => new ActorsDto
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'.",
                    })
                    .OrderBy(x => x.FullName)
                    .ToArray(),
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            foreach (var item in plays)
            {
                if (item.Rating.Equals("0"))
                {
                    item.Rating = "Premier";
                }
            }

            var serialized = XmlConverter.Serialize(plays, "Plays");
            return serialized;
        }
    }
}
