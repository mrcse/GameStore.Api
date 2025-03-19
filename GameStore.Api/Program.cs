
using GameStore.Api.Data;
using Serilog;

namespace GameStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Sqlite DbContext
            builder.Services.AddSqlite<GameStoreDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

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
            app.MigrateDb();

            app.Run();
        }
    }
}
