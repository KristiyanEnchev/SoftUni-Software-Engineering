using Git.Services.Contracts;
using Git.ViewModels.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = commitsService.CreateCommit(id);

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            var errors = commitsService.CreateNewCommit(model, this.User.Id);

            if (errors.Count != 0)
            {
                return Error(errors);
            }

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = commitsService.GetAllCommits(this.User.Id);

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var error = commitsService.DeleteCommit(id, this.User.Id);

            if (!string.IsNullOrEmpty(error) || !string.IsNullOrWhiteSpace(error))
            {
                return Error(error);
            }

            return Redirect("/Commits/All");
        }
    }
}
