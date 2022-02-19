namespace Andreys
{
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using Andreys.Data;
    using Andreys.Services.Contracts;
    using Andreys.Services.Service;
    using AutoMapper;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<AndreysDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IUserService, UserService>()
                .Add<IProductService, ProductService>()
                .Add<IMapper>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<AndreysDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
