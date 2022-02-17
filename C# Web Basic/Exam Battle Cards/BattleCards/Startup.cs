namespace BattleCards
{

    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using BattleCards.Data;
    using BattleCards.Services.Contracts;
    using BattleCards.Services.Service;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IValidatorService, ValidatorService>()
                    .Add<IUserService, UserService>()
                    .Add<ICardsService, CardsService>()
                    .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<ApplicationDbContext>(context => context.Database.Migrate())
                .Start();
    }
}
