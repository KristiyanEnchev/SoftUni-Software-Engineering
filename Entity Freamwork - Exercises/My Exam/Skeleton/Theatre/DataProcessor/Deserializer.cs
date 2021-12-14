namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using XmlFacade;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string root = "Plays";
            var playsDto = XmlConverter.Deserializer<ImportPlaysDto>(xmlString, root);

            List<Play> plays = new List<Play>();

            foreach (var playXml in playsDto)
            {
                if (!IsValid(playXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var duration = TimeSpan.ParseExact(playXml.Duration, "c", CultureInfo.InvariantCulture);
                if (duration.Hours < 01)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Genre genre;
                var isValidGenre = Enum.TryParse(playXml.Genre, out genre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre playGenre = (Genre)genre;


                var play = new Play
                {
                    Title = playXml.Title,
                    Duration = duration,
                    Rating = playXml.Rating,
                    Genre = genre,
                    Description = playXml.Description,
                    Screenwriter = playXml.Screenwriter,

                };

                plays.Add(play);

                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string root = "Casts";
            var castsDto = XmlConverter.Deserializer<ImportCastsDto>(xmlString, root);

            List<Cast> casts = new List<Cast>();

            foreach (var castXml in castsDto)
            {
                if (!IsValid(castXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = castXml.FullName,
                    IsMainCharacter = castXml.IsMainCharacter,
                    PhoneNumber = castXml.PhoneNumber,
                    PlayId = castXml.PlayId,
                };

                casts.Add(cast);

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter == true ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theaterJson = JsonConvert.DeserializeObject<IEnumerable<ImportTheatersWithTiketsDto>>(jsonString);

            List<Theatre> theatres = new List<Theatre>();

            foreach (var jsonTheater in theaterJson)
            {
                if (!IsValid(jsonTheater))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Ticket> tickets = new List<Ticket>();

                foreach (var ticketInfo in jsonTheater.Tickets)
                {
                    if (!IsValid(ticketInfo))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        Price = ticketInfo.Price,
                        RowNumber = ticketInfo.RowNumber,
                        PlayId = ticketInfo.PlayId,
                    };

                    tickets.Add(ticket);
                }

                var theatre = new Theatre
                {
                    Name = jsonTheater.Name,
                    NumberOfHalls = jsonTheater.NumberOfHalls,
                    Director = jsonTheater.Director,
                    Tickets = tickets,
                };

                theatres.Add(theatre);

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
