using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IMatchService
    {
        Task<IEnumerable<match>> GetAllMatchsAsync();
        Task<match> GetMatchAsync(string id);
        Task<IEnumerable<match>> AddMatchAsync(match match);
        Task<IEnumerable<match>> UpdateMatchAsync(match updateMatch);
        Task<IEnumerable<match>> DeleteMatchAsync(string deleteMatch);
    }
}
