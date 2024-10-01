using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Services
{
    public class RoundService: IRoundService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoundService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<round>> GetAllRoundsAsync()
        {
            return await _unitOfWork.RoundRepository.GetAllAsync();
        }
        public async Task<round> GetRoundAsync(string id)
        {
            return await _unitOfWork.RoundRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<round>> AddRoundAsync(round round)
        {
            await _unitOfWork.RoundRepository.AddAsync(round);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.RoundRepository.GetAllAsync();
        }
        public async Task<IEnumerable<round>> UpdateRoundAsync(round updateround)
        {
            var findround = await _unitOfWork.RoundRepository.GetByIdAsync(updateround.round_id);

            if (findround != null)
            {
                findround.date = updateround.date;
                findround.round_stage = updateround.round_stage;
                findround.match = updateround.match;
                

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Round not found.");
            }

            return await _unitOfWork.RoundRepository.GetAllAsync();
        }
        public async Task<IEnumerable<round>> DeleteRoundAsync(string deleteround)
        {
            var findround = await _unitOfWork.RoundRepository.GetByIdAsync(deleteround);

            if (findround != null)
            {
                await _unitOfWork.RoundRepository.DeleteAsync(findround.round_id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Round not found.");
            }

            return await _unitOfWork.RoundRepository.GetAllAsync();
        }
    }
}
