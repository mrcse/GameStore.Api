
using System.Threading.Tasks;
using GameStore.Api.Data;
using Serilog;

namespace GameStore.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            IConfiguration Configuration = builder.Configuration;

            // Set enviroment to development
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Inject Sqlite DbContext
            builder.Services.AddSqlite<GameStoreDbContext>(Configuration.GetConnectionString("DefaultConnection"));

            // Add Serilog
            builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration) // Read from appsettings.json
                .Enrich.FromLogContext() // Enrich logs with context
              );

            using var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Migrate the database
            await app.MigrateDbAsync();

            app.Run();
        }
    }
}
