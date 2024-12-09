using LaserTag_API.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using LaserTag_API.Core.Models;
namespace LaserTag.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet]
        public async Task<ActionResult<List<match>>> GetAllMatch()
        {
            var matchList = await _matchService.GetAllMatchsAsync();
            return Ok(matchList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<match>> GetMatch(string id)
        {
            var match = await _matchService.GetMatchAsync(id);
            if (match == null)
            {
                return BadRequest("Match not found");
            }
            return Ok(match);
        }
        [HttpPost]
        public async Task<ActionResult<List<match>>> AddMatch(match match)
        {
            var addmatch = await _matchService.AddMatchAsync(match);

            return Ok(addmatch);
        }
        [HttpPut]
        public async Task<ActionResult<List<match>>> UpdateMatch(match updateMatch)
        {
            var dbmatch = await _matchService.UpdateMatchAsync(updateMatch);

            return Ok(dbmatch);
        }

        [HttpDelete]
        public async Task<ActionResult<List<match>>> DeleteMatch(string id)
        {
            var match = await _matchService.DeleteMatchAsync(id);

            return Ok(match);
        }
    }
}
