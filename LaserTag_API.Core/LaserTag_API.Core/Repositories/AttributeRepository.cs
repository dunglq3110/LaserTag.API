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
    public class AttributeRepository : BaseRepository<attribute>,IAttributeRepository
    {
        private readonly AppDbContext _context;
        public AttributeRepository(AppDbContext context):base(context) 
        {
            this._context = context;
        }
        public async Task<IEnumerable<attribute>> GetAllAttributesAsync()
        {
            return await _context.Attributes.ToListAsync();
        }
        public async Task<attribute> GetAttributeAsync(int id)
        {
            return await _context.Attributes.FindAsync(id);
        }
        public async Task<IEnumerable<attribute>> AddAttribute(attribute attribute)
        {
            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();
            return await _context.Attributes.ToListAsync();
        }
        public async Task<IEnumerable<attribute>> UpdateAttribute(attribute updateattribute)
        {
            var findattribute = await _context.Attributes.FindAsync(updateattribute.id);

            if (findattribute != null)
            {
                findattribute.name = updateattribute.name;
                findattribute.description = updateattribute.description;
                findattribute.code_name = updateattribute.code_name;
                findattribute.is_gun = updateattribute.is_gun;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Attribute not found.");
            }

            return await _context.Attributes.ToListAsync();
        }
        public async Task<IEnumerable<attribute>> DeleteAttribute(int deleteattribute)
        {
            var findattribute = await _context.Attributes.FindAsync(deleteattribute);

            if (findattribute != null)
            {
                _context.Attributes.Remove(findattribute);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _context.Attributes.ToListAsync();
        }
    }
}
