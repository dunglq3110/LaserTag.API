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
    public class SharedGroupRepository : BaseRepository<shared_group>, ISharedGroupRepository
    {
        private readonly AppDbContext _context;
        public SharedGroupRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<shared_group>> GetAllSharedGroupsAsync()
        {
            return await _context.Shared_Groups.ToListAsync();
        }
        public async Task<shared_group> GetSharedGroupAsync(int id)
        {
            return await _context.Shared_Groups.FindAsync(id);
        }
        public async Task<IEnumerable<shared_group>> AddSharedGroup(shared_group sharedGroup)
        {
            _context.Shared_Groups.Add(sharedGroup);
            await _context.SaveChangesAsync();
            return await _context.Shared_Groups.ToListAsync();
        }
        public async Task<IEnumerable<shared_group>> UpdateSharedGroup(shared_group sharedGroup)
        {
            var findsharedGroup = await _context.Shared_Groups.FindAsync(sharedGroup.group_id);

            if (findsharedGroup != null)
            {
                findsharedGroup.group_name1 = sharedGroup.group_name1;
                findsharedGroup.group_name2 = sharedGroup.group_name2;
                findsharedGroup.group_name3 = sharedGroup.group_name3;
                findsharedGroup.group_name4 = sharedGroup.group_name4;
                findsharedGroup.group_name5 = sharedGroup.group_name5;
                findsharedGroup.description = sharedGroup.description;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Shared Group not found.");
            }

            return await _context.Shared_Groups.ToListAsync();
        }
        public async Task<IEnumerable<shared_group>> DeleteSharedGroup(int deletesharedgroup)
        {
            var findsharedGroup = await _context.Shared_Groups.FindAsync(deletesharedgroup);

            if (findsharedGroup != null)
            {
                _context.Shared_Groups.Remove(findsharedGroup);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Shared Group not found.");
            }

            return await _context.Shared_Groups.ToListAsync();
        }
    }
}
