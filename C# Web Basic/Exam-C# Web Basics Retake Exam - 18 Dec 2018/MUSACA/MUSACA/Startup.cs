namespace MUSACA
{
    using MyWebServer;
    using MUSACA.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using MUSACA.Services.Contracts;
    using MUSACA.Services.Service;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<ApplicationDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IOrdersService, OrderService>()
                .Add<IUserService, UserService>()
                .Add<IProductService, ProductService>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
