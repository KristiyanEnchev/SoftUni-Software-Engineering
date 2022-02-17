namespace BattleCards.Controllers
{
    using BattleCards.Services.Contracts;
    using BattleCards.ViewModels.Cards;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CardsController : Controller
    {
        private readonly ICardsService CardsService;

        public CardsController(ICardsService cardsService)
        {
            CardsService = cardsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var allcardsModel = CardsService.GetAllCardsModel();

            return View(allcardsModel);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var allUserCardsModel = CardsService.GetCollection(this.User.Id);

            return View(allUserCardsModel);
        }

        [Authorize]
        public HttpResponse AddToCollection(string cardId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var checkForErrors = CardsService.AddCardToUserCollection(this.User.Id, cardId);

            if (!string.IsNullOrEmpty(checkForErrors) || !string.IsNullOrWhiteSpace(checkForErrors))
            {
                return Error(checkForErrors);
            }

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(string cardId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            CardsService.RemoveCardFromColleection(this.User.Id, cardId);

            return Redirect("/Cards/All");
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
        public HttpResponse Add(CreateCardViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var checkForErrors = CardsService.CreateCard(model, this.User.Id);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return Redirect("/Cards/All");
        }
    }
}
