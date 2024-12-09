using LaserTag_API.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using LaserTag_API.Core.Models;
namespace LaserTag.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _roundService;
        public RoundController(IRoundService roundService)
        {
            _roundService = roundService;
        }
        [HttpGet]
        public async Task<ActionResult<List<round>>> GetAllRound()
        {
            var roundList = await _roundService.GetAllRoundsAsync();
            return Ok(roundList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<round>> GetRound(string id)
        {
            var round = await _roundService.GetRoundAsync(id);
            if (round == null)
            {
                return BadRequest("Round not found");
            }
            return Ok(round);
        }
        [HttpPost]
        public async Task<ActionResult<List<round>>> AddRound(round round)
        {
            var addround = await _roundService.AddRoundAsync(round);

            return Ok(addround);
        }
        [HttpPut]
        public async Task<ActionResult<List<round>>> UpdateRound(round updateRound)
        {
            var dbround = await _roundService.UpdateRoundAsync(updateRound);

            return Ok(dbround);
        }

        [HttpDelete]
        public async Task<ActionResult<List<round>>> DeleteRound(string id)
        {
            var round = await _roundService.DeleteRoundAsync(id);

            return Ok(round);
        }
    }
}
