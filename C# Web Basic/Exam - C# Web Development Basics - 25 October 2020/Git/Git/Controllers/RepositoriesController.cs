namespace Git.Controllers
{
    using Git.Services.Contracts;
    using Git.ViewModels.Repository;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService RepositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            RepositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repos = RepositoryService.GetAllPublicRepositories(this.User.Id);

            return this.View(repos);
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryViewModel model)
        {
            var checkForErrors = RepositoryService.CreateNewRepository(model, this.User.Id);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return Redirect("/Repositories/All");
        }
    }
}
