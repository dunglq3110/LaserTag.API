using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using LaserTag_API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController: ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<player>>> GetAllPlayer()
        {
            var playerList = await _playerService.GetAllPlayersAsync();
            return Ok(playerList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<player>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayersAsync(id);
            if(player == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(player);
        }
        [HttpPost]
        public async Task<ActionResult<List<player>>> AddPlayer(player player)
        {
            var addplayer = await _playerService.AddPlayerAsync(player);

            return Ok(addplayer);
        }
        [HttpPut]
        public async Task<ActionResult<List<player>>> UpdatePlayer(player updatePlayer)
        {
            var dbplayer = await _playerService.UpdatePlayerAsync(updatePlayer);

            return Ok(dbplayer);
        }

        [HttpDelete]
        public async Task<ActionResult<List<player>>> DeletePlayer(int id)
        {
            var player = await _playerService.DeletePlayerAsync(id);

            return Ok(player);
        }
    }
}
