using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Repositories
{
    public class PlayerRepository : BaseRepository<player>, IPlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task<player> GetPlayersAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }
        public async Task<IEnumerable<player>> AddPlayer(player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return await _context.Players.ToListAsync();
        }
        public async Task<IEnumerable<player>> UpdatePlayer(player updateplayer)
        {
            var findplayer = await _context.Players.FindAsync(updateplayer.id);

            if (findplayer != null)
            {
                findplayer.name = updateplayer.name;
                findplayer.mac_gun = updateplayer.mac_gun;
                findplayer.mac_vest = updateplayer.mac_vest;
                findplayer.current_health = updateplayer.current_health;
                findplayer.current_bullet = updateplayer.current_bullet;
                findplayer.balance = updateplayer.balance;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _context.Players.ToListAsync();
        }
        public async Task<IEnumerable<player>> DeletePlayer(string deleteplayer)
        {
            var findplayer = await _context.Players.FindAsync(deleteplayer);

            if (findplayer != null)
            {
                _context.Players.Remove(findplayer);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _context.Players.ToListAsync();
        }

    }
}
