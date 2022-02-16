namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using Controllers;
    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services;

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
                    .Add<IUserService, UserService>()
                    .Add<IValidator, Validator>()
                    .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<ApplicationDbContext>(context => context.Database.Migrate())
                .Start();
    }
}
