namespace Git.Services.Contracts
{
    using Git.ViewModels.Repository;
    using System.Collections.Generic;

    public interface IRepositoryService
    {
        public List<AllRepositoriesViewModel> GetAllPublicRepositories(string userId);
        List<string> CreateNewRepository(CreateRepositoryViewModel model, string ownerId);
        bool UserIsOwner(string userId);
    }
}
