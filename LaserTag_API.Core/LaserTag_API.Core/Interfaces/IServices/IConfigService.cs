using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IConfigService
    {
        Task<IEnumerable<config>> GetAllConfigsAsync();
        Task<config> GetConfigsAsync(string id);
        Task<IEnumerable<config>> AddConfigAsync(config config);
        Task<IEnumerable<config>> UpdateConfigAsync(config updateconfig);
        Task<IEnumerable<config>> DeleteConfigAsync(string deleteconfig);
    }
}
