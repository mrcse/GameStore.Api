
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

// Main Game DTO
public record GameDto(
     int Id,
     string? Title,
     string? Description,
     decimal Price,
     DateTime? ReleaseDate,
     string? Developer,
     string? Genre,
     string? ImageUrl,
     DateTime CreatedAt,
     DateTime UpdatedAt
);


// Create Game DTO
public record CreateGameDto(
     [Required][StringLength(50)] string Title,
     [StringLength(200)] string? Description,
     [Required][Range(1, 100)] decimal Price,
     DateTime? ReleaseDate,
     [StringLength(30)] string? Developer,
     [StringLength(20)] string? Genre,
     [Url] string? ImageUrl
);


// Update Game DTO
public record UpdateGameDto(
     string? Title,
     string? Description,
     [Range(1, 100)] decimal? Price,
     DateTime? ReleaseDate,
     string? Developer,
     string? Genre,
     string? ImageUrl

);