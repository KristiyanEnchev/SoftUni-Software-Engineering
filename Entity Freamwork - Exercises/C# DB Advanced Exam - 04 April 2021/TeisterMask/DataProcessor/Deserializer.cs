namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using XmlFacade;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string root = "Projects";
            var projectsDto = XmlConverter.Deserializer<ProjectInputModel>(xmlString, root);

            List<Project> projects = new List<Project>();

            foreach (var project in projectsDto)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime outDate;
                bool isValidDate = DateTime
                    .TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);

                DateTime? dueDate = null;
                bool isValidDateDueDate = false;

                if (!string.IsNullOrEmpty(project.DueDate))
                {
                    DateTime dueDateValue;
                    isValidDateDueDate = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateValue);

                    if (!isValidDateDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectt = new Project
                {
                    Name = project.Name,
                    OpenDate = outDate,
                    DueDate = dueDate,
                };

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOutDate;
                    bool isValidTaksDate = DateTime
                        .TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOutDate);

                    DateTime taskDueDate;
                    bool isValidTaskDueDate = DateTime
                        .TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isValidTaksDate || !isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOutDate < projectt.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate != null && taskDueDate > projectt.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskk = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOutDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                    };

                    projectt.Tasks.Add(taskk);
                }

                projects.Add(projectt);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, projectt.Name, projectt.Tasks.Count));
            }

            context.Projects.AddRange(projects);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtoEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeeInputModel>>(jsonString);

            List<Employee> employees = new List<Employee>();

            foreach (var employee in dtoEmployees)
            {
                if (!IsValid(employee) || employee.Username.Any(x => !char.IsLetterOrDigit(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employe = new Employee
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone
                };

                foreach (var task in employee.Tasks.Distinct())
                {
                    if (context.Tasks.All(x => x.Id != task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskk = context.Tasks.FirstOrDefault(x => x.Id == task);

                    var empTask = new EmployeeTask
                    {
                        Employee = employe,
                        Task = taskk
                    };

                    employe.EmployeesTasks.Add(empTask);
                }

                employees.Add(employe);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employe.Username, employe.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
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