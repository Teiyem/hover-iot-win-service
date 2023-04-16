using Hover.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

            builder.Services.AddWindowsService();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}