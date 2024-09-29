using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface IRoundService
    {
        Task<IEnumerable<round>> GetAllRoundsAsync();
        Task<round> GetRoundAsync(string id);
        Task<IEnumerable<round>> AddRoundAsync(round round);
        Task<IEnumerable<round>> UpdateRoundAsync(round updateround);
        Task<IEnumerable<round>> DeleteRoundAsync(string deleteround);
    }
}
