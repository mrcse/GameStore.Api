using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class CreateGameDto
{
    public required string Title { get; init; } 
    public string? Description { get; init; }
    public required decimal Price { get; init; }
    public string? Publisher { get; init; }
    public required DateTime ReleaseDate { get; init; }
    public string? Developer { get; init; }
    public string? Genre { get; init; }
    public string? Platform { get; init; }
    public string? ImageUrl { get; init; }
    public string? TrailerUrl { get; init; }
    public string? Website { get; init; }
    public string? ESRB { get; init; }
    public string? Rating { get; init; }
    public string? Status { get; init; }
    public int? Quantity { get; init; }
    public int? Views { get; init; }
    public int? Likes { get; init; }
    public int? Dislikes { get; init; }
    public int? Downloads { get; init; }
    public int? Purchases { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

}
