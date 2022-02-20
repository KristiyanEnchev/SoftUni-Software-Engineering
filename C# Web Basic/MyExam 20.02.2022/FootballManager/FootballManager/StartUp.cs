namespace FootballManager
{
    using MyWebServer;
    using FootballManager.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using FootballManager.Services.Contracts;
    using FootballManager.Services.Service;
    using AutoMapper;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IUserService, UserService>()
                .Add<IPlayerService, PlayerService>()
                .Add<IMapper>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
