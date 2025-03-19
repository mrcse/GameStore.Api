using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(ILogger<GameController> logger, GameStoreDbContext dbContext) : ControllerBase
    {


        // Get all games
        [HttpGet(Name = "GetGames")]
        public ActionResult<IEnumerable<GameDto>> Get()
        {
            // Log information
            logger.LogInformation("Getting all games");

            // Gett all games and map toDto also map the developer and genre
            var games = dbContext.Games.Include(g => g.Developer).Include(g => g.Genre).AsNoTracking().ToList();
            return games.Select(g => g.ToDto()).ToList();

        }

        // Get games using pagination
        [HttpGet("GetPaginatedGames", Name = "GetPaginatedGames")]
        public ActionResult<IEnumerable<GameDto>> GetPaginatedGames([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // Log information
            logger.LogInformation("Getting paginated games");

            // Get games using pagination and map toDto also map the developer and genre
            var games = dbContext.Games.Include(g => g.Developer).Include(g => g.Genre).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();

            // The response body should have include tootal records current page and total pages

            var totalRecords = dbContext.Games.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);


            return Ok(
                new
                {
                    TotalRecords = totalRecords,
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Data = games.Select(g => g.ToDto()).ToList()
                }
            );
        }

        // Get game by id
        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<GameDto> Get(int id)
        {
            // Log information
            logger.LogInformation("Getting game by id: {Id}", id);
            var game = dbContext.Games.Include(g => g.Developer).Include(g => g.Genre).AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (game is null)
            {
                return NotFound();
            }
            return game.ToDto();
        }


        // Create a new game
        [HttpPost(Name = "CreateGame")]
        public ActionResult<GameDto> Post([FromBody] CreateGameDto createGameDto)
        {
            // Log information
            logger.LogInformation("Creating a new game");

            var developer = dbContext.Find<Developer>(createGameDto.DeveloperId);


            // Check if the developer exists
            if (developer is null)
            {
                return BadRequest("Developer not found");
            }


            var genre = dbContext.Find<Genre>(createGameDto.GenreId);

            // Check if the genre exists
            if (genre is null)
            {
                return BadRequest("Genre not found");
            }

            Game game = createGameDto.ToEntity();

            dbContext.Add(game);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetGame", new { id = game.Id }, game.ToDto());
        }


        // Update a game
        [HttpPut("{id}", Name = "UpdateGame")]
        public ActionResult<GameDto> Put(int id, [FromBody] UpdateGameDto updateGameDto)
        {
            // Log information
            logger.LogInformation("Updating game by id: {Id}", id);

            // Update the game by id and update fields that are given
            var game = dbContext.Find<Game>(id);
            if (game is null)
            {
                return NotFound();
            }

            if (updateGameDto.DeveloperId != null)
            {
                var developer = dbContext.Find<Developer>(updateGameDto.DeveloperId);
                if (developer is null)
                {
                    return BadRequest("Developer not found");
                }
                game.Developer = developer;
            }

            if (updateGameDto.GenreId != null)
            {
                var genre = dbContext.Find<Genre>(updateGameDto.GenreId);
                if (genre is null)
                {
                    return BadRequest("Genre not found");
                }
                game.Genre = genre;
            }



            game.Title = updateGameDto.Title ?? game.Title;
            game.Description = updateGameDto.Description ?? game.Description;
            game.Price = updateGameDto.Price ?? game.Price;
            game.ReleaseDate = updateGameDto.ReleaseDate ?? game.ReleaseDate;
            game.ImageUrl = updateGameDto.ImageUrl ?? game.ImageUrl;
            game.UpdatedAt = DateTime.Now;

            dbContext.SaveChanges();

            return NoContent();
        }

        // Delete a game
        [HttpDelete("{id}", Name = "DeleteGame")]
        public ActionResult Delete(int id)
        {
            // Log information
            logger.LogInformation("Deleting game by id: {Id}", id);

            var game = dbContext.Find<Game>(id);
            if (game is null)
            {
                return NotFound();
            }

            dbContext.Remove(game);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
