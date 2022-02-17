namespace CarShop.Services.Service
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services.Contracts;
    using CarShop.ViewModels.Issues;
    using System.Collections.Generic;
    using System.Linq;

    public class IssueService : BaseService<Issue>, IIssueService
    {
        private readonly IUserService UserService;

        public IssueService(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher, IUserService userService)
            : base(data, validator, passwordHasher)
        {
            UserService = userService;
        }

        public List<string> AddNewIssue(IssueFormViewModel model, string carId)
        {
            var errors = this.Validator.ValidateModel(model);

            if (errors.Count != 0)
            {
                return errors.ToList();
            }

            var car = this.Data.Cars.FirstOrDefault(x => x.Id == carId);
            var issue = new Issue
            {
                Description = model.Description,
                CarId = carId,
                Car = car,
            };

            car.Issues.Add(issue);

            Data.SaveChanges();

            return errors.ToList();
        }

        public string DeleteIssue(string issueId, string carId, string userId)
        {
            var error = string.Empty;

            if (!UserService.IsMechanic(userId))
            {
                return error = "You canot Delete Issues, You dont have a permission";
            }

            var issue = this.Data.Issues.FirstOrDefault(x => x.Id == issueId);
            this.Data.Issues.Remove(issue);

            this.Data.SaveChanges();

            return error;
        }

        public string FixIssue(string issueId, string carId, string userId)
        {
            var error = string.Empty;

            if (!UserService.IsMechanic(userId))
            {
                return error = "You canot Fix Issues, You dont have a permission";
            }

            var issue = this.Data.Issues.FirstOrDefault(x => x.Id == issueId);
            issue.IsFixed = true;
            this.Data.SaveChanges();

            return error;
        }

        public CarIssueViewModel GetCarIssues(string carId) 
        {
            var car = this.Data.Cars.FirstOrDefault(x => x.Id == carId);
            var issues = this.All().Where(x => x.CarId == carId);

            var model = new CarIssueViewModel
            {
                CarId = carId,
                CarModel = car.Model,
            };

            model.Issues = new List<IssueViewModel>();

            foreach (var issue in issues)
            {
                model.Issues.Add(new IssueViewModel {Description = issue.Description, IssueId = issue.Id, IsFixed = issue.IsFixed == true ? "Yes" : "Not Yet" });
            }

            return model;
        }
    }
}
