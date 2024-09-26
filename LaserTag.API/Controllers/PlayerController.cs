using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        public async Task<ActionResult<List<player>>> GetAllPlayer()
        {
            var playerList = await _unitOfWork.PlayerRepository.GetAllPlayersAsync();
            return Ok(playerList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<player>> GetPlayer(int id)
        {
            var player = await _unitOfWork.PlayerRepository.GetPlayersAsync(id);
            if(player == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(player);
        }
        [HttpPost]
        public async Task<ActionResult<List<player>>> AddPlayer(player player)
        {
            var addplayer = await _unitOfWork.PlayerRepository.AddPlayer(player);

            return Ok(addplayer);
        }
        [HttpPut]
        public async Task<ActionResult<List<player>>> UpdatePlayer(player updatePlayer)
        {
            var dbplayer = await _unitOfWork.PlayerRepository.UpdatePlayer(updatePlayer);

            return Ok(dbplayer);
        }

        [HttpDelete]
        public async Task<ActionResult<List<player>>> DeletePlayer(int id)
        {
            var player = await _unitOfWork.PlayerRepository.DeletePlayer(id);

            return Ok(player);
        }
    }
}
