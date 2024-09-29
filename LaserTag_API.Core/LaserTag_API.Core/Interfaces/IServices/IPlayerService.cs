using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IPlayerService
    {
        Task<IEnumerable<player>> GetAllPlayersAsync();
        Task<player> GetPlayersAsync(string id);
        Task<IEnumerable<player>> AddPlayerAsync(player player);
        Task<IEnumerable<player>> UpdatePlayerAsync(player updateplayer);
        Task<IEnumerable<player>> DeletePlayerAsync(string deleteplayer);
    }
}
