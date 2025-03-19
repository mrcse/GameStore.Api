using GameStore.Api.Data;
using GameStore.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController(ILogger<GameController> logger, GameStoreDbContext dbContext) : ControllerBase
    {

        // Get All Developers
        [HttpGet(Name = "GetDevelopers")]
        public async Task<ActionResult<IEnumerable<DeveloperDto>>> GetDevelopers()
        {
            logger.LogInformation("Getting all developers");
            var developers = await dbContext.Developers.ToListAsync();
            return Ok(developers);
        }
    }
}
