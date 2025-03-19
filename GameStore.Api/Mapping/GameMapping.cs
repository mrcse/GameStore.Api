using GameStore.Api.DTOs;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{

    // To Entity method 
    public static Game ToEntity(this CreateGameDto createGameDto)
    {
        return new Game
        {
            Title = createGameDto.Title,
            Description = createGameDto.Description,
            Price = createGameDto.Price,
            ReleaseDate = createGameDto.ReleaseDate,
            ImageUrl = createGameDto.ImageUrl,
            DeveloperId = createGameDto.DeveloperId,
            GenreId = createGameDto.GenreId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }


    // To Dto method
    public static GameDto ToDto(this Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            ImageUrl = game.ImageUrl,
            Developer = game.Developer?.Name,
            Genre = game.Genre?.Name,
            CreatedAt = game.CreatedAt,
            UpdatedAt = game.UpdatedAt
        };
    }
}
