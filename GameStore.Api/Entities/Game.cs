using System;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? ImageUrl { get; set; }
    public int DeveloperId { get; set; }
    public Developer? Developer { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
