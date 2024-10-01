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
    public class HitLogService : IHitLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HitLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<hit_log>> GetAllHitLogsAsync()
        {
            return await _unitOfWork.HitLogRepository.GetAllAsync();
        }
        public async Task<hit_log> GetHitLogAsync(string id)
        {
            return await _unitOfWork.HitLogRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<hit_log>> AddHitLogAsync(hit_log hit_log)
        {
            await _unitOfWork.HitLogRepository.AddAsync(hit_log);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.HitLogRepository.GetAllAsync();

        }
        public async Task<IEnumerable<hit_log>> UpdateHitLogAsync(hit_log updatehitlog)
        {
            var findhitlog = await _unitOfWork.HitLogRepository.GetByIdAsync(updatehitlog.hit_log_id);

            if (findhitlog != null)
            {
                findhitlog.source_player = updatehitlog.source_player;
                findhitlog.target_player = updatehitlog.target_player;
                findhitlog.round = updatehitlog.round;
                findhitlog.hit_type = updatehitlog.hit_type;
                findhitlog.value = updatehitlog.value;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _unitOfWork.HitLogRepository.GetAllAsync();
        }
        public async Task<IEnumerable<hit_log>> DeleteHitLogAsync(string deletehitlog)
        {
            var findhitlog = await _unitOfWork.HitLogRepository.GetByIdAsync(deletehitlog);

            if (findhitlog != null)
            {
                await _unitOfWork.HitLogRepository.DeleteAsync(findhitlog.hit_log_id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Hit-Log not found.");
            }

            return await _unitOfWork.HitLogRepository.GetAllAsync();
        }
    }
}
