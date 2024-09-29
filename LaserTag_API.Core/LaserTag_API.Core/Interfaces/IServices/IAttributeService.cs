using LaserTag_API.Core.Models;
using LaserTag_API.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IAttributeService
    {
        Task<IEnumerable<attribute>> GetAllAttributesAsync();
        Task<attribute> GetAttributesAsync(string id);
        Task<IEnumerable<attribute>> AddAttributeAsync(attribute attribute);
        Task<IEnumerable<attribute>> UpdateAttributeAsync(attribute updateattribute);
        Task<IEnumerable<attribute>> DeleteAttributeAsync(string deleteattribute);
    }
}
