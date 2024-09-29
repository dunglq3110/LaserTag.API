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
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<player>> GetAllPlayersAsync()
        {
            return await _unitOfWork.PlayerRepository.GetAllAsync();
        }
        public async Task<player> GetPlayersAsync(string id)
        {
            return await _unitOfWork.PlayerRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<player>> AddPlayerAsync(player player)
        {
            await _unitOfWork.PlayerRepository.AddAsync(player);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.PlayerRepository.GetAllAsync();
        }
        public async Task<IEnumerable<player>> UpdatePlayerAsync(player updateplayer)
        {
            var findplayer = await _unitOfWork.PlayerRepository.GetByIdAsync(updateplayer.id);

            if (findplayer != null)
            {
                findplayer.name = updateplayer.name;
                findplayer.mac_gun = updateplayer.mac_gun;
                findplayer.mac_vest = updateplayer.mac_vest;
                findplayer.current_health = updateplayer.current_health;
                findplayer.current_bullet = updateplayer.current_bullet;
                findplayer.balance = updateplayer.balance;

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _unitOfWork.PlayerRepository.GetAllAsync();
        }
        public async Task<IEnumerable<player>> DeletePlayerAsync(string deleteplayer)
        {
            var findplayer = await _unitOfWork.PlayerRepository.GetByIdAsync(deleteplayer);

            if (findplayer != null)
            {
                await _unitOfWork.PlayerRepository.DeleteAsync(findplayer.id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _unitOfWork.PlayerRepository.GetAllAsync();
        }
    }
}
