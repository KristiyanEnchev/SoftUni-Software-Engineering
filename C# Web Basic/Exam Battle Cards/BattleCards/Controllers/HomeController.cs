namespace BattleCards.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Cards/All");
            }

            return this.View();
        }
    }
}