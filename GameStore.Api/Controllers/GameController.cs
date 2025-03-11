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
            (                1,
                "Cyberpunk 2077",
                "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.",
                59.99m,
                "CD Projekt Red",
                new DateTime(2020, 12, 10),
                "CD Projekt Red",
                "Action, RPG",
                "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/capsule_616x353.jpg?t=1607700317",
                "https://www.youtube.com/watch?v=BO8lX3hDU30",
                "https://www.cyberpunk.net",
                "Mature",
                "9.0",
                "Active",
                100,
                1000,
                500,
                50,
                1000,
                500,
                DateTime.Now,
                DateTime.Now
            ),
            new GameDto
            (
                2,
                "The Witcher 3: Wild Hunt",
                "The Witcher 3: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.",
                39.99m,
                "CD Projekt Red",
                new DateTime(2015, 5, 19),
                "CD Projekt Red",
                "Action, RPG",
                "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                "https://cdn.cloudflare.steamstatic.com/steam/apps/292030/capsule_616x353.jpg?t=1607700317",
                "https://www.youtube.com/watch?v=c0i88t0Kacs",
                "https://www.thewitcher.com",
                "Mature",
                "9.8",
                "Active",
                100,
                1000,
                500,
                50,
                1000,
                500,
                DateTime.Now,
                DateTime.Now
            ),
            new GameDto
            (
                3,
                "Red Dead Redemption 2",
                "America, 1899. The end of the wild west era has begun as lawmen hunt down the last remaining outlaw gangs.",
                59.99m,
                "Rockstar Games",
                new DateTime(2018, 10, 26),
                "Rockstar Games",
                "Action, Adventure",
                "PC, PS4, PS5, Xbox One, Xbox Series X/S",
                "https://cdn.cloudflare.steamstatic.com/steam/apps/1174180/capsule_616x353.jpg?t=1607700317",
                "https://www.youtube.com/watch?v=eaW0tYpxyp0",
                "https://www.rockstargames.com/reddeadredemption2",
                "Mature",
                "9.5",
                "Active",
                100,
                1000,
                500,
                50,
                1000,
                500,
                DateTime.Now,
                DateTime.Now
            ),
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
            GameDto game = new(
                games.Count + 1,
                createGameDto.Title,
                createGameDto.Description,
                createGameDto.Price,
                createGameDto.Publisher,
                createGameDto.ReleaseDate,
                createGameDto.Developer,
                createGameDto.Genre,
                createGameDto.Platform,
                createGameDto.ImageUrl,
                createGameDto.TrailerUrl,
                createGameDto.Website,
                createGameDto.ESRB,
                createGameDto.Rating,
                createGameDto.Status,
                createGameDto.Quantity,
                createGameDto.Views,
                createGameDto.Likes,
                createGameDto.Dislikes,
                createGameDto.Downloads,
                createGameDto.Purchases,
                DateTime.Now,
                DateTime.Now
            );
            games.Add(game);
            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }


        // Update a game
        [HttpPut("{id}", Name = "UpdateGame")]
        public ActionResult<GameDto> Put(int id, [FromBody] UpdateGameDto updateGameDto)
        {
            // Log information
            logger.LogInformation("Updating game by id: {Id}", id);
            int index = games.FindIndex(g => g.Id == id);
            if (index < 0)
            {
                return NotFound();
            }

            // Update Game fields

            GameDto updatedFieldOfGame = new(
            id,
            updateGameDto.Title ?? games[index].Title,
            updateGameDto.Description ?? games[index].Description,
            updateGameDto.Price ?? games[index].Price,
            updateGameDto.Publisher ?? games[index].Publisher,
            updateGameDto.ReleaseDate ?? games[index].ReleaseDate,
            updateGameDto.Developer ?? games[index].Developer,
            updateGameDto.Genre ?? games[index].Genre,
            updateGameDto.Platform ?? games[index].Platform,
            updateGameDto.ImageUrl ?? games[index].ImageUrl,
            updateGameDto.TrailerUrl ?? games[index].TrailerUrl,
            updateGameDto.Website ?? games[index].Website,
            updateGameDto.ESRB ?? games[index].ESRB,
            updateGameDto.Rating ?? games[index].Rating,
            updateGameDto.Status ?? games[index].Status,
            updateGameDto.Quantity ?? games[index].Quantity,
            updateGameDto.Views ?? games[index].Views,
            updateGameDto.Likes ?? games[index].Likes,
            updateGameDto.Dislikes ?? games[index].Dislikes,
            updateGameDto.Downloads ?? games[index].Downloads,
            updateGameDto.Purchases ?? games[index].Purchases,
            games[index].CreatedAt,
            DateTime.Now

           );
            games[index] = updatedFieldOfGame;

            return NoContent();
        }

        // Delete a game
        [HttpDelete("{id}", Name = "DeleteGame")]
        public ActionResult Delete(int id)
        {
            // Log information
            logger.LogInformation("Deleting game by id: {Id}", id);
            int index = games.FindIndex(g => g.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            games.RemoveAt(index);
            return NoContent();
        }
    }
}
