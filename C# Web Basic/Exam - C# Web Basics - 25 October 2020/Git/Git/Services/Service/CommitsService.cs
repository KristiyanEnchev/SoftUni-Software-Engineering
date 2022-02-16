namespace Git.Services.Service
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services.Contracts;
    using Git.ViewModels.Commits;
    using System.Collections.Generic;
    using System.Linq;

    public class CommitsService : BaseService<Commit>, ICommitsService
    {
        public CommitsService(ApplicationDbContext data, IValidatorService validator)
            : base(data, validator)
        {
        }

        public CommitToRepositoryViewModel CreateCommit(string id)
        {
            var repository = this.Data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            return repository;
        }

        public List<CommitListingViewModel> GetAllCommits(string userId)
        {
            var commits = this.Data
                .Commits
                .Where(c => c.CreatorId == userId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F"),
                    Repository = c.Repository.Name
                })
                .ToList();

            return commits;
        }
        public List<string> CreateNewCommit(CreateCommitFormModel model, string userId) 
        {
            ICollection<string> modelErrors = Validator.ValidateModel(model);

            if (!this.Data.Repositories.Any(r => r.Id == model.Id))
            {
                modelErrors.Add("Already Exists");
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = userId
            };

            this.Data.Commits.Add(commit);

            this.Data.SaveChanges();

            return modelErrors.ToList();
        }

        public string DeleteCommit(string commitId, string userId) 
        {
            var commit = this.All()
                .FirstOrDefault(x => x.Id == commitId);

            string error = string.Empty;

            if (commit == null || commit.CreatorId != userId)
            {
                error = "Bad Request";
                return error;
            }

            this.Data.Commits.Remove(commit);

            this.Data.SaveChanges();

            return error;
        }
    }
}
