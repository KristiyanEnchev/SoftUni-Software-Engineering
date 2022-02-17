namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.ViewModels.Albums;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService AlbumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.AlbumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var albums = this.AlbumsService.GetAllAlbums();

            return View(albums);
        }


        [Authorize]
        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateAlbumViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var checkForErrors = AlbumsService.CreateAlbum(model);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            var model = this.AlbumsService.GetDetails(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
