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
    public class ShootLogService : IShootLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShootLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<shoot_log>> GetAllShootLogsAsync()
        {
            return await _unitOfWork.ShootLogRepository.GetAllAsync();
        }
        public async Task<shoot_log> GetShootLogAsync(string id)
        {
            return await _unitOfWork.ShootLogRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<shoot_log>> AddShootLogAsync(shoot_log shoot_log)
        {
            await _unitOfWork.ShootLogRepository.AddAsync(shoot_log);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.ShootLogRepository.GetAllAsync();

        }
        public async Task<IEnumerable<shoot_log>> UpdateShootLogAsync(shoot_log updatehitlog)
        {
            var findhitlog = await _unitOfWork.ShootLogRepository.GetByIdAsync(updatehitlog.shoot_log_id);

            if (findhitlog != null)
            {
                findhitlog.player = updatehitlog.player;
                findhitlog.round = updatehitlog.round;
                findhitlog.date = updatehitlog.date;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _unitOfWork.ShootLogRepository.GetAllAsync();
        }
        public async Task<IEnumerable<shoot_log>> DeleteShootLogAsync(string deletehitlog)
        {
            var findhitlog = await _unitOfWork.ShootLogRepository.GetByIdAsync(deletehitlog);

            if (findhitlog != null)
            {
                await _unitOfWork.ShootLogRepository.DeleteAsync(findhitlog.shoot_log_id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _unitOfWork.ShootLogRepository.GetAllAsync();
        }
    }
}
