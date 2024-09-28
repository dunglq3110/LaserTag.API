using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttributeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<attribute>> GetAllAttributesAsync()
        {
            return await _unitOfWork.AttributeRepository.GetAllAsync();
        }
        public async Task<attribute> GetAttributesAsync(int id)
        {
            return await _unitOfWork.AttributeRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<attribute>> AddAttributeAsync(attribute attribute)
        {
            await _unitOfWork.AttributeRepository.AddAsync(attribute);
            await _unitOfWork.SaveChangesAsyncLasertag();
            return await _unitOfWork.AttributeRepository.GetAllAsync();
        }
        public async Task<IEnumerable<attribute>> UpdateAttributeAsync(attribute updateattribute)
        {
            var findattribute = await _unitOfWork.AttributeRepository.GetByIdAsync(updateattribute.id);

            if (findattribute != null)
            {
                findattribute.name = updateattribute.name;
                findattribute.description = updateattribute.description;
                findattribute.code_name = updateattribute.code_name;
                findattribute.is_gun = updateattribute.is_gun;

                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Player not found.");
            }

            return await _unitOfWork.AttributeRepository.GetAllAsync();
        }
        public async Task<IEnumerable<attribute>> DeleteAttributeAsync(int deleteattribute)
        {
            var findattribute = await _unitOfWork.AttributeRepository.GetByIdAsync(deleteattribute);

            if (findattribute != null)
            {
                await _unitOfWork.AttributeRepository.DeleteAsync(findattribute.id);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsyncLasertag();
            }
            else
            {
                throw new Exception("Attribute not found.");
            }

            return await _unitOfWork.AttributeRepository.GetAllAsync();
        }
    }
}
