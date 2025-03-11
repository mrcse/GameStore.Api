
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

// Main Game DTO
public record GameDto(
     int Id,
     string? Title,
     string? Description,
     decimal Price,
     string? Publisher,
     DateTime? ReleaseDate,
     string? Developer,
     string? Genre,
     string? Platform,
     string? ImageUrl,
     string? TrailerUrl,
     string? Website,
     string? ESRB,
     string? Rating,
     string? Status,
     int? Quantity,
     int? Views,
     int? Likes,
     int? Dislikes,
     int? Downloads,
     int? Purchases,
     DateTime CreatedAt,
     DateTime UpdatedAt
);


// Create Game DTO
public record CreateGameDto(
     [Required][StringLength(50)] string  Title,
     [StringLength(200)] string? Description,
     [Required][Range(1, 100)] decimal Price,
     [StringLength(30)] string? Publisher,
     DateTime? ReleaseDate,
     [StringLength(30)] string? Developer,
     [StringLength(20)] string? Genre,
     [StringLength(20)] string? Platform,
     [Url] string? ImageUrl,
     [Url] string? TrailerUrl,
     [Url] string? Website,
     [StringLength(20)] string? ESRB,
     string? Rating,
     [StringLength(10)] string? Status,
     int? Quantity,
     int? Views,
     int? Likes,
     int? Dislikes,
     int? Downloads,
     int? Purchases
);


// Update Game DTO
public record UpdateGameDto(
     string? Title,
     string? Description,
     [Range(1,100)]decimal? Price,
     string? Publisher,
     DateTime? ReleaseDate,
     string? Developer,
     string? Genre,
     string? Platform,
     string? ImageUrl,
     string? TrailerUrl,
     string? Website,
     string? ESRB,
     string? Rating,
     string? Status,
     int? Quantity,
     int? Views,
     int? Likes,
     int? Dislikes,
     int? Downloads,
     int? Purchases
);