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

    public class ShootLogRepository : BaseRepository<shoot_log>, IShootLogRepository
    {
        private readonly AppDbContext _context;
        public ShootLogRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<shoot_log>> GetAllShootLogsAsync()
        {
            return await _context.Shoot_Logs.ToListAsync();
        }
        public async Task<shoot_log> GetShootLogAsync(int id)
        {
            return await _context.Shoot_Logs.FindAsync(id);
        }
        public async Task<IEnumerable<shoot_log>> AddShootLog(shoot_log hitlog)
        {
            _context.Shoot_Logs.Add(hitlog);
            await _context.SaveChangesAsync();
            return await _context.Shoot_Logs.ToListAsync();
        }
        public async Task<IEnumerable<shoot_log>> UpdateShootLog(shoot_log updatehitlog)
        {
            var findhitlog = await _context.Shoot_Logs.FindAsync(updatehitlog.shoot_log_id);

            if (findhitlog != null)
            {
                findhitlog.player = updatehitlog.player;
                findhitlog.date = updatehitlog.date;
                findhitlog.round = updatehitlog.round;
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _context.Shoot_Logs.ToListAsync();
        }
        public async Task<IEnumerable<shoot_log>> DeleteShootLog(string deletehitlog)
        {
            var findhitlog = await _context.Shoot_Logs.FindAsync(deletehitlog);

            if (findhitlog != null)
            {
                _context.Shoot_Logs.Remove(findhitlog);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _context.Shoot_Logs.ToListAsync();
        }
    }
}
