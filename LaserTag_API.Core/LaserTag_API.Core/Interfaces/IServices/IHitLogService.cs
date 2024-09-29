using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IHitLogService
    {
        Task<IEnumerable<hit_log>> GetAllHitLogsAsync();
        Task<hit_log> GetHitLogAsync(string id);
        Task<IEnumerable<hit_log>> AddHitLogAsync(hit_log hit_log);
        Task<IEnumerable<hit_log>> UpdateHitLogAsync(hit_log updatehitlog);
        Task<IEnumerable<hit_log>> DeleteHitLogAsync(string deletehitlog);
    }
}
