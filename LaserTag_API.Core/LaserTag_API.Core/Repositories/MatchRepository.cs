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
    public class MatchRepository : BaseRepository<match>, IMatchRepository
    {
        private readonly AppDbContext _context;
        public MatchRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<match>> GetAllMatchsAsync()
        {
            return await _context.Matches.ToListAsync();
        }
        public async Task<match> GetMatchAsync(int id)
        {
            return await _context.Matches.FindAsync(id);
        }
        public async Task<IEnumerable<match>> AddMatch(match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return await _context.Matches.ToListAsync();
        }
        public async Task<IEnumerable<match>> UpdateMatch(match updatematch)
        {
            var findmatch = await _context.Matches.FindAsync(updatematch.id);

            if (findmatch != null)
            {
                findmatch.date = updatematch.date;
                findmatch.stage = updatematch.stage;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Match not found.");
            }

            return await _context.Matches.ToListAsync();
        }
        public async Task<IEnumerable<match>> DeleteMatch(string deletematch)
        {
            var findmatch = await _context.Matches.FindAsync(deletematch);

            if (findmatch != null)
            {
                _context.Matches.Remove(findmatch);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Match not found.");
            }

            return await _context.Matches.ToListAsync();
        }
    }
}
