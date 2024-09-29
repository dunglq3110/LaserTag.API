using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Services
{
    public class SharedService : ISharedService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SharedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Shared Base
        public async Task<IEnumerable<shared_base>> GetAllSharedBaseAsync()
        {
            return await _unitOfWork.SharedBaseRepository.GetAllAsync();
        }

        public async Task<shared_base> GetSharedBaseByBaseId(string baseId)
        {
            return await _unitOfWork.SharedBaseRepository.GetByIdAsync(baseId);
        }
        public async Task<IEnumerable<shared_base>> CreateNewSharedBaseAsync(shared_base sharedBase)
        {
            await _unitOfWork.SharedBaseRepository.AddAsync(sharedBase);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.SharedBaseRepository.GetAllAsync();
        }
        public async Task<IEnumerable<shared_base>> UpdateSharedBaseAsync(shared_base sharedBase)
        {
            var findsharedBase = await _unitOfWork.SharedBaseRepository.GetByIdAsync(sharedBase.base_id);

            if (findsharedBase != null)
            {
                findsharedBase.group_id = sharedBase.group_id;
                findsharedBase.base_name1 = sharedBase.base_name1;
                findsharedBase.base_name2 = sharedBase.base_name2;
                findsharedBase.base_name3 = sharedBase.base_name3;
                findsharedBase.base_name4 = sharedBase.base_name4;
                findsharedBase.base_name5 = sharedBase.base_name5;
                findsharedBase.sort = sharedBase.sort;
                findsharedBase.description = sharedBase.description;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Shared Base not found.");
            }

            return await _unitOfWork.SharedBaseRepository.GetAllAsync();
        }

        public async Task<IEnumerable<shared_base>> DeleteSharedBaseAsync(string sharedBase)
        {
            var findsharedBase = await _unitOfWork.SharedBaseRepository.GetByIdAsync(sharedBase);

            if (findsharedBase != null)
            {
                _unitOfWork.SharedBaseRepository.DeleteAsync(findsharedBase.base_id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Shared Base not found.");
            }

            return await _unitOfWork.SharedBaseRepository.GetAllAsync();
        }
        #endregion

        #region Shared Group
        public async Task<IEnumerable<shared_group>> GetAllSharedGroupAsync()
        {
            return await _unitOfWork.SharedGroupRepository.GetAllAsync();
        }

        public async Task<shared_group> GetSharedGroupByGroupId(string groupId)
        {
            return await _unitOfWork.SharedGroupRepository.GetByIdAsync(groupId);
        }

        public async Task<IEnumerable<shared_group>> CreateNewSharedGroupAsync(shared_group sharedGroup)
        {
            await _unitOfWork.SharedGroupRepository.AddAsync(sharedGroup);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.SharedGroupRepository.GetAllAsync();
        }

        public async Task<IEnumerable<shared_group>> UpdateSharedGroupAsync(shared_group sharedGroup)
        {
            var findsharedGroup = await _unitOfWork.SharedGroupRepository.GetByIdAsync(sharedGroup.group_id);

            if (findsharedGroup != null)
            {
                findsharedGroup.group_name1 = sharedGroup.group_name1;
                findsharedGroup.group_name2 = sharedGroup.group_name2;
                findsharedGroup.group_name3 = sharedGroup.group_name3;
                findsharedGroup.group_name4 = sharedGroup.group_name4;
                findsharedGroup.group_name5 = sharedGroup.group_name5;
                findsharedGroup.description = sharedGroup.description;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Shared Group not found.");
            }

            return await _unitOfWork.SharedGroupRepository.GetAllAsync();
        }

        public async Task<IEnumerable<shared_group>> DeleteSharedGroupAsync(string sharedGroup)
        {
            var findsharedGroup = await _unitOfWork.SharedGroupRepository.GetByIdAsync(sharedGroup);

            if (findsharedGroup != null)
            {
                _unitOfWork.SharedGroupRepository.DeleteAsync(findsharedGroup.group_id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Shared Group not found.");
            }

            return await _unitOfWork.SharedGroupRepository.GetAllAsync();
        }
        #endregion
    }
}
