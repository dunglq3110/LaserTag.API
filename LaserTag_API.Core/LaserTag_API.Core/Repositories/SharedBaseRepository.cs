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
    public class SharedBaseRepository : BaseRepository<shared_base>, ISharedBaseRepository
    {
        private readonly AppDbContext _context;
        public SharedBaseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<shared_base>> GetAllSharedBasesAsync()
        {
            return await _context.Shared_Bases.ToListAsync();
        }
        public async Task<shared_base> GetSharedBaseAsync(int id)
        {
            return await _context.Shared_Bases.FindAsync(id);
        }
        public async Task<IEnumerable<shared_base>> AddSharedBase(shared_base sharedBase)
        {
            _context.Shared_Bases.Add(sharedBase);
            await _context.SaveChangesAsync();
            return await _context.Shared_Bases.ToListAsync();
        }
        public async Task<IEnumerable<shared_base>> UpdateSharedBase(shared_base sharedBase)
        {
            var findsharedBase = await _context.Shared_Bases.FindAsync(sharedBase.base_id);

            if (findsharedBase != null)
            {
                findsharedBase.group_id = sharedBase.group_id;
                findsharedBase.base_name1 = sharedBase.base_name1;
                findsharedBase.base_name2 = sharedBase.base_name2;
                findsharedBase.base_name3 = sharedBase.base_name3;
                findsharedBase.base_name4 = sharedBase.base_name4;
                findsharedBase.base_name5 = sharedBase.base_name5;
                findsharedBase.sort = sharedBase.sort;
                findsharedBase.description = sharedBase.description;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Shared Base not found.");
            }

            return await _context.Shared_Bases.ToListAsync();
        }
        public async Task<IEnumerable<shared_base>> DeleteSharedBase(string deletesharedBase)
        {
            var findsharedBase = await _context.Shared_Bases.FindAsync(deletesharedBase);

            if (findsharedBase != null)
            {
                _context.Shared_Bases.Remove(findsharedBase);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Shared Base not found.");
            }

            return await _context.Shared_Bases.ToListAsync();
        }
    }
}
