namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Services.Contracts;
    using SMS.Services;
    using SMS.Data;
    using SMS.Contracts.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<SMSDbContext>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IValidator, Validator>()
                    .Add<IUserService, UserService>()
                    .Add<ICartService, CartService>()
                    .Add<IProductService, ProductService>()
                    .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<SMSDbContext>(context => context.Database.Migrate())
                .Start();
    }
}