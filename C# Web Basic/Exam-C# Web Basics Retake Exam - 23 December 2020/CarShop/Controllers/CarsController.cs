namespace CarShop.Controllers
{
    using CarShop.Services.Contracts;
    using CarShop.ViewModels.Cars;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private readonly ICarService CarService;

        public CarsController(ICarService carService)
        {
            CarService = carService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cars = CarService.GetAllCarsForUser(this.User.Id);

            return this.View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            var isMechanic = CarService.UserIsmechanic(this.User.Id);

            if (isMechanic)
            {
                return Error("Mechanics cannot add cars.");
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarListingViewModel model)
        {
            var checkForErrors = CarService.AddCar(model, this.User.Id);

            if (checkForErrors.Count != 0)
            {
                return Error(checkForErrors);
            }

            return Redirect("./All");
        }
    }
}
