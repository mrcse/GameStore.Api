
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtentions
{

    // Method to migrate the database
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
        await context.Database.MigrateAsync();
    }

}
