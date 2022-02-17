namespace IRunes
{
    using IRunes.Data;
    using IRunes.Services.Contracts;
    using IRunes.Services.Services;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<IRunesDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IUserService, UserService>()
                .Add<ITracksService, TracksService>()
                .Add<IAlbumsService, AlbumsService>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<IRunesDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
