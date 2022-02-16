namespace Git.Services.Service
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services.Contracts;
    using Git.ViewModels.Repository;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class RepositoryService : BaseService<Repository>, IRepositoryService
    {
        public RepositoryService(ApplicationDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public List<AllRepositoriesViewModel> GetAllPublicRepositories(string userId)
        {
            var repo = this.All().AsQueryable();

            if (userId != null)
            {
                repo = repo.Where(x => x.IsPublic || x.OwnerId == userId);
            }
            else
            {
                repo = repo.Where(x => x.IsPublic);
            }

            var repositores = repo
                .OrderByDescending(r => r.CreatedOn)
                .Select(x => new AllRepositoriesViewModel
                {
                    RepositoryId = x.Id,
                    RepositoryName = x.Name,
                    RepositoryOwner = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToLocalTime().ToString("F"),
                    CommitCount = x.Commits.Count()
                })
                .ToList();

            return repositores;
        }

        public List<string> CreateNewRepository(CreateRepositoryViewModel model, string ownerId) 
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (modelErrors.Count != 0)
            {
                return modelErrors.ToList();
            }

            var repo = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                CreatedOn = DateTime.Now,
                OwnerId = ownerId
            };

            this.Data.Repositories.Add(repo);

            this.Data.SaveChanges();

            return modelErrors.ToList();
        }

        public bool UserIsOwner(string userId) 
        {
            if (this.Data.Repositories.Where(x => x.OwnerId == userId).Any())
            {
                return true;
            }

            return false;
        }
    }
}
