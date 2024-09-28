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
    public class ConfigRepository : BaseRepository<config>, IConfigRepository
    {
        private readonly AppDbContext _context;
        public ConfigRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<config>> GetAllConfigsAsync()
        {
            return await _context.Configs.ToListAsync();
        }
        public async Task<config> GetConfigsAsync(int id)
        {
            return await _context.Configs.FindAsync(id);
        }
        public async Task<IEnumerable<config>> AddConfig(config config)
        {
            _context.Configs.Add(config);
            await _context.SaveChangesAsync();
            return await _context.Configs.ToListAsync();
        }
        public async Task<IEnumerable<config>> UpdatePlayer(config updateconfig)
        {
            var findconfig = await _context.Configs.FindAsync(updateconfig.config_id);

            if (findconfig != null)
            {
                findconfig.name = updateconfig.name;
                findconfig.code_name = updateconfig.code_name;
                findconfig.config_type_id = updateconfig.config_type_id;
                findconfig.value1 = updateconfig.value1;
                findconfig.value2 = updateconfig.value2;
                findconfig.value3 = updateconfig.value3;
                findconfig.value4 = updateconfig.value4;
                findconfig.value5 = updateconfig.value5;
                findconfig.description = updateconfig.description;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Config not found.");
            }

            return await _context.Configs.ToListAsync();
        }
        public async Task<IEnumerable<config>> DeleteConfig(int deleteconfig)
        {
            var findconfig = await _context.Configs.FindAsync(deleteconfig);

            if (findconfig != null)
            {
                _context.Configs.Remove(findconfig);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _context.Configs.ToListAsync();
        }
    }
}
