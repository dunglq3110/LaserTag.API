using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<match>> GetAllMatchsAsync()
        {
            return await _unitOfWork.MatchRepository.GetAllAsync();
        }
        public async Task<match> GetMatchAsync(string id)
        {
            return await _unitOfWork.MatchRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<match>> AddMatchAsync(match match)
        {
            await _unitOfWork.MatchRepository.AddAsync(match);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.MatchRepository.GetAllAsync();
        }
        public async Task<IEnumerable<match>> UpdateMatchAsync(match updateMatch)
        {
            var findMatch = await _unitOfWork.MatchRepository.GetByIdAsync(updateMatch.id);

            if (findMatch != null)
            {
                findMatch.date = updateMatch.date;
                findMatch.stage = updateMatch.stage;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Match not found.");
            }

            return await _unitOfWork.MatchRepository.GetAllAsync();
        }
        public async Task<IEnumerable<match>> DeleteMatchAsync(string deleteMatch)
        {
            var findMatch = await _unitOfWork.MatchRepository.GetByIdAsync(deleteMatch);

            if (findMatch != null)
            {
                await _unitOfWork.MatchRepository.DeleteAsync(findMatch.id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Match not found.");
            }

            return await _unitOfWork.MatchRepository.GetAllAsync();
        }
    }
}
