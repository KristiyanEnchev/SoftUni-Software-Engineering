namespace Git.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Repositories/All");
            }

            return this.View();
        }
    }
}
