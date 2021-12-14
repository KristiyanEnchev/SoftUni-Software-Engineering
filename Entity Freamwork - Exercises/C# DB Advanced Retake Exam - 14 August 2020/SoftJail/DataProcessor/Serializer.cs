namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using XmlFacade;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisonersByCells = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                    .Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name,
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(x => x.Officer.Salary).ToString("F2")),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var serializedEmployees = JsonConvert.SerializeObject(prisonersByCells, Formatting.Indented);
            return serializedEmployees;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            List<string> prisonerNames = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var prisonersMail = context.Prisoners
                .Where(x => prisonerNames.Contains(x.FullName))
                .Select(x => new ExportPrisonerDto()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(y => new EncryptedMessagesDto()
                    {
                        Description = MailDescriptionReverse(y.Description)
                    })
                    .ToArray(),
                })
                .OrderBy(x => x.FullName)
                .ThenBy(x => x.Id)
                .ToArray();

            var serializedEProject = XmlConverter.Serialize(prisonersMail, "Prisoners");
            return serializedEProject;
        }

        private static string MailDescriptionReverse(string description)
        {
            char[] charArray = description.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}