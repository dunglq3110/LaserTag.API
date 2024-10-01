using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConfigService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<config>> GetAllConfigsAsync()
        {
            return await _unitOfWork.ConfigRepository.GetAllAsync();
        }
        public async Task<config> GetConfigsAsync(string id)
        {
            return await _unitOfWork.ConfigRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<config>> AddConfigAsync(config config)
        {
            await _unitOfWork.ConfigRepository.AddAsync(config);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.ConfigRepository.GetAllAsync();
        }
        public async Task<IEnumerable<config>> UpdateConfigAsync(config updateconfig)
        {
            var findconfig = await _unitOfWork.ConfigRepository.GetByIdAsync(updateconfig.config_id);

            if (findconfig != null)
            {
                findconfig.name = updateconfig.name;
                findconfig.code_name = updateconfig.code_name;
                findconfig.config_type = updateconfig.config_type;
                findconfig.value1 = updateconfig.value1;
                findconfig.value2 = updateconfig.value2;
                findconfig.value3 = updateconfig.value3;
                findconfig.value4 = updateconfig.value4;
                findconfig.value5 = updateconfig.value5;
                findconfig.description = updateconfig.description;

                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _unitOfWork.ConfigRepository.GetAllAsync();
        }
        public async Task<IEnumerable<config>> DeleteConfigAsync(string deleteconfig)
        {
            var findconfig = await _unitOfWork.ConfigRepository.GetByIdAsync(deleteconfig);

            if (findconfig != null)
            {
                await _unitOfWork.ConfigRepository.DeleteAsync(findconfig.config_id);

                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Config not found.");
            }

            return await _unitOfWork.ConfigRepository.GetAllAsync();
        }
    }
}
