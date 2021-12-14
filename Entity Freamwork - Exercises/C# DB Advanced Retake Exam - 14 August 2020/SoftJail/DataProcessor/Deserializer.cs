namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using XmlFacade;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentCells = JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentsCellsDto>>(jsonString);

            List<Department> departments = new List<Department>();

            foreach (var department in departmentCells)
            {
                if (!IsValid(department))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (department.Cells.Count() <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Cell> cells = new List<Cell>();

                foreach (var cell in department.Cells)
                {
                    if (!IsValid(cell))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var theCell = new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow,
                    };

                    cells.Add(theCell);
                }

                if (cells.Count < department.Cells.Count())
                {
                    continue;
                }

                var theDepartment = new Department()
                {
                    Name = department.Name,
                    Cells = cells,
                };

                departments.Add(theDepartment);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }

            context.Departments.AddRange(departments);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonerMails = JsonConvert.DeserializeObject<IEnumerable<ImportPrisonerMailsDto>>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerJson in prisonerMails)
            {
                if (!IsValid(prisonerJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(prisonerJson.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                DateTime incarserationDate;
                bool isIncarserationDateValid = DateTime.TryParseExact(prisonerJson.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarserationDate);

                List<Mail> mails = new List<Mail>();

                foreach (var mailJson in prisonerJson.Mails)
                {
                    if (!IsValid(mailJson.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var mail = new Mail()
                    {
                        Description = mailJson.Description,
                        Sender = mailJson.Sender,
                        Address = mailJson.Address,
                    };

                    mails.Add(mail);
                }

                if (mails.Count < prisonerJson.Mails.Count())
                {
                    break;
                }

                var prisoner = new Prisoner()
                {
                    FullName = prisonerJson.FullName,
                    Nickname = prisonerJson.Nickname,
                    Age = prisonerJson.Age,
                    IncarcerationDate = incarserationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerJson.Bail,
                    CellId = prisonerJson.CellId,
                    Mails = mails,
                };

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var officersXml = XmlConverter.Deserializer<ImportOfficersPrisonersDto>(xmlString, "Officers");

            List<Officer> officers = new List<Officer>();

            foreach (var xmlOfficer in officersXml)
            {
                if (!IsValid(xmlOfficer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object position;
                bool isValidPosiotion = Enum.TryParse(typeof(Position), xmlOfficer.Position, out position);

                object weapon;
                bool isValidweapon = Enum.TryParse(typeof(Weapon), xmlOfficer.Weapon, out weapon);

                if (!isValidPosiotion || !isValidweapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                Position officerPosition = (Position)position;
                Weapon officerWeapon = (Weapon)weapon;

                var officer = new Officer()
                {
                    FullName = xmlOfficer.FullName,
                    Salary = xmlOfficer.Salary,
                    Position = officerPosition,
                    Weapon = officerWeapon,
                    DepartmentId = xmlOfficer.DepartmentId,
                };

                List<OfficerPrisoner> officerPrisoners = new List<OfficerPrisoner>();

                foreach (var prisonerXml in xmlOfficer.Prisoners)
                {
                    var prisonerOfficer = new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisonerXml.Id,
                    };

                    officerPrisoners.Add(prisonerOfficer);
                    officer.OfficerPrisoners.Add(prisonerOfficer);
                }

                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}