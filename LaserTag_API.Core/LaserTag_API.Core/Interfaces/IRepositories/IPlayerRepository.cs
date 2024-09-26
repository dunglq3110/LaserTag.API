using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<player>> GetAllPlayersAsync();
        Task<player> GetPlayersAsync(int id);
        Task<IEnumerable<player>> AddPlayer(player player);
        Task<IEnumerable<player>> UpdatePlayer(player updateplayer);
        Task<IEnumerable<player>> DeletePlayer(int deleteplayer);
    }
}
