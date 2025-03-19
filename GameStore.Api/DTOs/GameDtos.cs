
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

// Main Game DTO
public record GameDto
{
     public int Id { get; init; }
     public string? Title { get; init; }
     public string? Description { get; init; }
     public decimal Price { get; init; }
     public DateTime? ReleaseDate { get; init; }
     public string? Developer { get; init; }
     public string? Genre { get; init; }
     public string? ImageUrl { get; init; }
     public DateTime CreatedAt { get; init; }
     public DateTime UpdatedAt { get; init; }
}


// Create Game DTO
// Create Game DTO
public record CreateGameDto
{
     [StringLength(50, MinimumLength = 3)]
     public required string Title { get; init; }

     [StringLength(200)]
     public string? Description { get; init; }

     [Range(1, 500)]
     public required decimal Price { get; init; }

     public DateTime? ReleaseDate { get; init; }

     public required int DeveloperId { get; init; }

     public required int GenreId { get; init; }

     [Url]
     public string? ImageUrl { get; init; }
}

// Update Game DTO
public record UpdateGameDto
{
     [StringLength(50)]
     public string? Title { get; init; }

     [StringLength(200)]
     public string? Description { get; init; }

     [Range(1, 100)]
     public decimal? Price { get; init; }

     public DateTime? ReleaseDate { get; init; }

     public int? DeveloperId { get; init; }

     public int? GenreId { get; init; }

     [Url]
     public string? ImageUrl { get; init; }
}