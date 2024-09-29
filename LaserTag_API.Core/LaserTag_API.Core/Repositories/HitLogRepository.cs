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
    public class HitLogRepository : BaseRepository<hit_log>, IHitLogRepository
    {
        private readonly AppDbContext _context;
        public HitLogRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<hit_log>> GetAllHitLogsAsync()
        {
            return await _context.Hit_Logs.ToListAsync();
        }
        public async Task<hit_log> GetHitLogAsync(int id)
        {
            return await _context.Hit_Logs.FindAsync(id);
        }
        public async Task<IEnumerable<hit_log>> AddHitLog(hit_log hitlog)
        {
            _context.Hit_Logs.Add(hitlog);
            await _context.SaveChangesAsync();
            return await _context.Hit_Logs.ToListAsync();
        }
        public async Task<IEnumerable<hit_log>> UpdateHitLog(hit_log updatehitlog)
        {
            var findhitlog = await _context.Hit_Logs.FindAsync(updatehitlog.hit_log_id);

            if (findhitlog != null)
            {
                findhitlog.source_player = updatehitlog.source_player;
                findhitlog.target_player = updatehitlog.target_player;
                findhitlog.round = updatehitlog.round;
                findhitlog.hit_type = updatehitlog.hit_type;
                findhitlog.value = updatehitlog.value;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _context.Hit_Logs.ToListAsync();
        }
        public async Task<IEnumerable<hit_log>> DeleteHitLog(string deletehitlog)
        {
            var findhitlog = await _context.Hit_Logs.FindAsync(deletehitlog);

            if (findhitlog != null)
            {
                _context.Hit_Logs.Remove(findhitlog);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _context.Hit_Logs.ToListAsync();
        }
    }
}
