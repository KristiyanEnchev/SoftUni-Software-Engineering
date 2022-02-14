namespace Git.Services.Contracts
{
    using Git.ViewModels.Commits;
    using System.Collections.Generic;

    public interface ICommitsService
    {
        CommitToRepositoryViewModel CreateCommit(string id);
        List<CommitListingViewModel> GetAllCommits(string userId);
        string DeleteCommit(string commitId, string userId);
        List<string> CreateNewCommit(CreateCommitFormModel model, string userId);
    }
}
