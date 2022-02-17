namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.ViewModels.Tracks;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class TracksController : Controller
    {
        private readonly ITracksService TrackService;

        public TracksController(ITracksService trackService)
        {
            TrackService = trackService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var tracksCreateViewModel = new TracksCreateViewModel
            {
                AlbumId = albumId
            };

            return this.View(tracksCreateViewModel);
        }

        [HttpPost]
        public HttpResponse Create(string albumId, CreateTrackViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var checkForerrors = TrackService.CreateTrack(model, albumId);

            if (checkForerrors.Count != 0)
            {
                return Error(checkForerrors);
            }

            return Redirect($"/Albums/Details?id={albumId}");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var detailsModel = TrackService.GetDetails(trackId, albumId);

            return View(detailsModel);
        }
    }
}
