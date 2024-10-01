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
    public class RoundRepository : BaseRepository<round>, IRoundRepository
    {
        private readonly AppDbContext _context;
        public RoundRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<round>> GetAllRoundsAsync()
        {
            return await _context.Rounds.ToListAsync();
        }
        public async Task<round> GetRoundAsync(int id)
        {
            return await _context.Rounds.FindAsync(id);
        }
        public async Task<IEnumerable<round>> AddRound(round round)
        {
            _context.Rounds.Add(round);
            await _context.SaveChangesAsync();
            return await _context.Rounds.ToListAsync();
        }
        public async Task<IEnumerable<round>> UpdateRound(round updateround)
        {
            var findround = await _context.Rounds.FindAsync(updateround.round_id);

            if (findround != null)
            {
                findround.date = updateround.date;
                findround.round_stage = updateround.round_stage;
                findround.match = updateround.match;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Round not found.");
            }

            return await _context.Rounds.ToListAsync();
        }
        public async Task<IEnumerable<round>> DeleteRound(string deleteRound)
        {
            var findRound = await _context.Rounds.FindAsync(deleteRound);

            if (findRound != null)
            {
                _context.Rounds.Remove(findRound);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Round not found.");
            }

            return await _context.Rounds.ToListAsync();
        }
    }
}
