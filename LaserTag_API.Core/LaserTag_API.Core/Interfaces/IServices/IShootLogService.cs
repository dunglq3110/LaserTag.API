using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IShootLogService
    {
        Task<IEnumerable<shoot_log>> GetAllShootLogsAsync();
        Task<shoot_log> GetShootLogAsync(string id);
        Task<IEnumerable<shoot_log>> AddShootLogAsync(shoot_log shoot_log);
        Task<IEnumerable<shoot_log>> UpdateShootLogAsync(shoot_log updatehitlog);
        Task<IEnumerable<shoot_log>> DeleteShootLogAsync(string deletehitlog);
    }
}
