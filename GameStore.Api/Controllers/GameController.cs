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
                createGameDto.ReleaseDate,
                createGameDto.Developer,
                createGameDto.Genre,
                createGameDto.ImageUrl,
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
                updateGameDto.ReleaseDate ?? games[index].ReleaseDate,
                updateGameDto.Developer ?? games[index].Developer,
                updateGameDto.Genre ?? games[index].Genre,
                updateGameDto.ImageUrl ?? games[index].ImageUrl,
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
