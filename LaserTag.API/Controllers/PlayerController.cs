using LaserTag_API.Core.Data;
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
        public PlayerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<player>>> GetAllPlayer()
        {
            var playerList = await _context.Players.ToListAsync();
            return Ok(playerList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if(player == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(player);
        }
        [HttpPost]
        public async Task<ActionResult<List<player>>> AddPlayer(player player)
        {
            // The 'id' should not be set manually
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return Ok(await _context.Players.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<player>>> UpdatePlayer(player updatePlayer)
        {
            var dbplayer = await _context.Players.FindAsync(updatePlayer.id);

            if (dbplayer == null)
                return NotFound("The player not found");

            dbplayer.name = updatePlayer.name;
            dbplayer.mac_gun = updatePlayer.mac_gun;
            dbplayer.mac_vest = updatePlayer.mac_vest;
            dbplayer.current_health = updatePlayer.current_health;
            dbplayer.current_bullet = updatePlayer.current_bullet;

            await _context.SaveChangesAsync();

            return Ok(await _context.Players.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<player>>> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound("The player not found");

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(await _context.Players.ToListAsync());
        }
    }
}
