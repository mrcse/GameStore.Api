using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Seed Genres
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Action" },
            new { Id = 2, Name = "Adventure" },
            new { Id = 3, Name = "RPG" },
            new { Id = 4, Name = "Simulation" },
            new { Id = 5, Name = "Strategy" },
            new { Id = 6, Name = "Sports" },
            new { Id = 7, Name = "Puzzle" },
            new { Id = 8, Name = "Horror" },
            new { Id = 9, Name = "MMO" },
            new { Id = 10, Name = "Racing" }
        );

        // Seed Top 10 Developers
        modelBuilder.Entity<Developer>().HasData(
            new { Id = 1, Name = "Ubisoft" },
            new { Id = 2, Name = "Rockstar Games" },
            new { Id = 3, Name = "CD Projekt Red" },
            new { Id = 4, Name = "Bethesda Game Studios" },
            new { Id = 5, Name = "Naughty Dog" },
            new { Id = 6, Name = "Nintendo" },
            new { Id = 7, Name = "Valve" },
            new { Id = 8, Name = "Epic Games" },
            new { Id = 9, Name = "Blizzard Entertainment" },
            new { Id = 10, Name = "Square Enix" }
        );

    }
}
