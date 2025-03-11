using GameStore.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(ILogger<GameController> logger) : ControllerBase
    {
        private static readonly List<GameDto> games = [
            // Generate some fake data
            new GameDto
            {
                Id = 1,
                Title = "Cyberpunk 2077",
                Description = "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.",
                Price = 59.99m,
                Publisher = "CD Projekt Red",
                ReleaseDate = new DateTime(2020, 12, 10),
                Developer = "CD Projekt Red",
                Genre = "Action, RPG",
                Platform = "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/capsule_616x353.jpg?t=1607700317",
                TrailerUrl = "https://www.youtube.com/watch?v=BO8lX3hDU30",
                Website = "https://www.cyberpunk.net",
                ESRB = "Mature",
                Rating = "9.0",
                Status = "Active",
                Quantity = 100,
                Views = 1000,
                Likes = 500,
                Dislikes = 50,
                Downloads = 1000,
                Purchases = 500,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new GameDto
            {
                Id = 2,
                Title = "The Witcher 3: Wild Hunt",
                Description = "The Witcher 3: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.",
                Price = 39.99m,
                Publisher = "CD Projekt Red",
                ReleaseDate = new DateTime(2015, 5, 19),
                Developer = "CD Projekt Red",
                Genre = "Action, RPG",
                Platform = "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/292030/capsule_616x353.jpg?t=1607700317",
                TrailerUrl = "https://www.youtube.com/watch?v=c0i88t0Kacs",
                Website = "https://www.thewitcher.com",
                ESRB = "Mature",
                Rating = "9.8",
                Status = "Active",
                Quantity = 100,
                Views = 1000,
                Likes = 500,
                Dislikes = 50,
                Downloads = 1000,
                Purchases = 500,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new GameDto
            {
                Id =3,
                Title = "Red Dead Redemption 2",
                Description = "America, 1899. The end of the wild west era has begun as lawmen hunt down the last remaining outlaw gangs.",
                Price = 59.99m,
                Publisher = "Rockstar Games",
                ReleaseDate = new DateTime(2018, 10, 26),
                Developer = "Rockstar Games",
                Genre = "Action, Adventure",
                Platform = "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1174180/capsule_616x353.jpg?t=1607700317",
                TrailerUrl = "https://www.youtube.com/watch?v=eaW0tYpxyp0",
                Website = "https://www.rockstargames.com/reddeadredemption2",
                ESRB = "Mature",
                Rating = "9.5",
                Status = "Active",
                Quantity = 100,
                Views = 1000,
                Likes = 500,
                Dislikes = 50,
                Downloads = 1000,
                Purchases = 500,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            // new GameDto
            // {
            //     Id = 4,
            //     Title = "Grand Theft Auto V",
            //     Description = "When a young street hustler, a retired bank robber and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.",
            //     Price = 29.99m,
            //     Publisher = "Rockstar Games",
            //     ReleaseDate = new DateTime(2013, 9, 17),
            //     Developer = "Rockstar North",
            //     Genre = "Action, Adventure",
            //     Platform = "PC, PS3, PS4, PS5, Xbox 360, Xbox One, Xbox Series X/S",
            //     ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/271590/capsule_616x353.jpg?t=1607700317",
            //     TrailerUrl = "https://www.youtube.com/watch?v=QkkoHAzjnUs",
            //     Website = "https://www.rockstargames.com/V",
            //     ESRB = "Mature",
            //     Rating = "9.5",
            //     Status = "Active",
            //     Quantity = 100,
            //     Views = 1000,
            //     Likes = 500,
            //     Dislikes = 50,
            //     Downloads = 1000,
            //     Purchases = 500,
            //     CreatedAt = DateTime.Now,
            //     UpdatedAt = DateTime.Now
            // }
        ];


        // Get all games
        [HttpGet(Name = "GetGames")]
        public ActionResult<IEnumerable<GameDto>> Get()
        {
            // Log information
            logger.LogInformation("Getting all games");
            return Ok(games);
        }

        // Get game by id
        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<GameDto> Get(int id)
        {
            // Log information
            logger.LogInformation("Getting game by id: {Id}", id);
            GameDto? game = games.FirstOrDefault(g => g.Id == id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }


        // Create a new game
        [HttpPost(Name = "CreateGame")]
        public ActionResult<GameDto> Post([FromBody] CreateGameDto createGameDto)
        {
            // Log information
            logger.LogInformation("Creating a new game");
            GameDto game = new()
            {
                Id = games.Count + 1,
                Title = createGameDto.Title,
                Description = createGameDto.Description,
                Price = createGameDto.Price,
                Publisher = createGameDto.Publisher,
                ReleaseDate = createGameDto.ReleaseDate,
                Developer = createGameDto.Developer,
                Genre = createGameDto.Genre,
                Platform = createGameDto.Platform,
                ImageUrl = createGameDto.ImageUrl,
                TrailerUrl = createGameDto.TrailerUrl,
                Website = createGameDto.Website,
                ESRB = createGameDto.ESRB,
                Rating = createGameDto.Rating,
                Status = createGameDto.Status,
                Quantity = createGameDto.Quantity,
                Views = createGameDto.Views,
                Likes = createGameDto.Likes,
                Dislikes = createGameDto.Dislikes,
                Downloads = createGameDto.Downloads,
                Purchases = createGameDto.Purchases,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            games.Add(game);
            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }


        // Update a game
        [HttpPut("{id}", Name = "UpdateGame")]
        public ActionResult<GameDto> Put(int id, [FromBody] UpdateGameDto updateGameDto)
        {
            // Log information
            logger.LogInformation("Updating game by id: {Id}", id);
            GameDto? game = games.FirstOrDefault(g => g.Id == id);
            if (game is null)
            {
                return NotFound();
            }

            game.Title = updateGameDto.Title ?? game.Title;
            game.Description = updateGameDto.Description ?? game.Description;
            game.Price = updateGameDto.Price ?? game.Price;
            game.Publisher = updateGameDto.Publisher ?? game.Publisher;
            game.ReleaseDate = updateGameDto.ReleaseDate ?? game.ReleaseDate;
            game.Developer = updateGameDto.Developer ?? game.Developer;
            game.Genre = updateGameDto.Genre ?? game.Genre;
            game.Platform = updateGameDto.Platform ?? game.Platform;
            game.ImageUrl = updateGameDto.ImageUrl ?? game.ImageUrl;
            game.TrailerUrl = updateGameDto.TrailerUrl ?? game.TrailerUrl;
            game.Website = updateGameDto.Website ?? game.Website;
            game.ESRB = updateGameDto.ESRB ?? game.ESRB;
            game.Rating = updateGameDto.Rating ?? game.Rating;
            game.Status = updateGameDto.Status ?? game.Status;
            game.Quantity = updateGameDto.Quantity ?? game.Quantity;
            game.Views = updateGameDto.Views ?? game.Views;
            game.Likes = updateGameDto.Likes ?? game.Likes;
            game.Dislikes = updateGameDto.Dislikes ?? game.Dislikes;
            game.Downloads = updateGameDto.Downloads ?? game.Downloads;
            game.Purchases = updateGameDto.Purchases ?? game.Purchases;

            return NoContent();
        }
    }
}
