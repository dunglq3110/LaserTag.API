using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Interfaces.IServices
{
    public interface ISharedService
    {
        #region Shared Base
        Task<IEnumerable<shared_base>> GetAllSharedBaseAsync();
        Task<shared_base> GetSharedBaseByBaseId(string baseId);
        Task<IEnumerable<shared_base>> CreateNewSharedBaseAsync(shared_base sharedBase);

        Task<IEnumerable<shared_base>> UpdateSharedBaseAsync(shared_base sharedBase);
        Task<IEnumerable<shared_base>> DeleteSharedBaseAsync(string sharedBase);
        #endregion

        #region Shared Group
        Task<IEnumerable<shared_group>> GetAllSharedGroupAsync();
        Task<shared_group> GetSharedGroupByGroupId(string groupId);
        Task<IEnumerable<shared_group>> CreateNewSharedGroupAsync(shared_group sharedGroup);
        Task<IEnumerable<shared_group>> UpdateSharedGroupAsync(shared_group sharedGroup);
        Task<IEnumerable<shared_group>> DeleteSharedGroupAsync(string sharedGroup);
        #endregion
    }
}
