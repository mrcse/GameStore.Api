using GameStore.Api.Data;
using GameStore.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(ILogger<GameController> logger, GameStoreDbContext dbContext) : ControllerBase
    {
        // Get All Genre
        [HttpGet(Name = "GetGenres")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
        {
            logger.LogInformation("Getting all genres");
            var genres = await dbContext.Genres.ToListAsync();
            return Ok(genres);
        }

    }
}
