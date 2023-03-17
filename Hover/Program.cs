namespace Hover
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main function of the program.
        /// Configure the services that are used by the application and starts the web application.
        /// </summary>
        /// <param name="args">The arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            RegisterServices(builder.Services);
            
            builder.Services.AddControllers();

            builder.Services.AddWindowsService();

            var app = builder.Build();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Registers all the services that are used by the application.
        /// </summary>
        /// <param name="collection">Collection of services to add the services to.</param>
        private static void RegisterServices(IServiceCollection collection)
        {
        }
    }
}