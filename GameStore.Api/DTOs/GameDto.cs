using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class GameDto
{
    public int Id { get; init; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Publisher { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Developer { get; set; }
    public string? Genre { get; set; }
    public string? Platform { get; set; }
    public string? ImageUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public string? Website { get; set; }
    public string? ESRB { get; set; }
    public string? Rating { get; set; }
    public string? Status { get; set; }
    public int? Quantity { get; set; }
    public int? Views { get; set; }
    public int? Likes { get; set; }
    public int? Dislikes { get; set; }
    public int? Downloads { get; set; }
    public int? Purchases { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

}
