namespace FootballManager.Controllers
{
    using FootballManager.Services.Contracts;
    using FootballManager.ViewModels.Players;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var allcardsModel = playerService.GetAllPlayersModel();

            return View(allcardsModel);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var allUserPlayersModel = playerService.GetCollection(this.User.Id);

            return View(allUserPlayersModel);
        }

        [Authorize]
        public HttpResponse AddToCollection(string playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var id = this.User.Id;

            var checkForErrors = playerService.AddplayerToUserCollection(this.User.Id, playerId);

            if (!string.IsNullOrEmpty(checkForErrors) || !string.IsNullOrWhiteSpace(checkForErrors))
            {
                return Error(checkForErrors);
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(string playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            playerService.RemovePlayerFromColleection(this.User.Id, playerId);

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CreatePlayerViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var checkForErrors = playerService.CreatePlayer(model, this.User.Id);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return Redirect("/Players/All");
        }
    }
}
