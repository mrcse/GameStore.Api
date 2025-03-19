
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtentions
{

    // Method to migrate the database
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
        context.Database.Migrate();
    }

}
