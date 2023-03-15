using Domain.DTO;
using Domain.Entities;
using Domain.Interfeces.IRepositories;
using Domain.Interfeces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MySQLServices
{
    public class ResolutionService : IResolutionService
    {
        private readonly IResolutionRepository _resolutionRepository;

        public ResolutionService(IResolutionRepository resolutionRepository)
        {
            _resolutionRepository = resolutionRepository;
        }

        public List<ResolutionDTO> FindAll()
        {
            return _resolutionRepository.FindAll()
                .Select(x => new ResolutionDTO()
                {
                    id = x.Id,
                    description = x.Description,
                    createdOn = x.CreatedOn,
                    spending = x.Spending,
                    image = x.Image
                }).ToList();
        }

        public async Task<ResolutionDTO> FindById(int id)
        {
            Resolution resolution = await _resolutionRepository.FindById(id);

            return new ResolutionDTO()
            {
                id = resolution.Id,
                description = resolution.Description,
                createdOn = resolution.CreatedOn,
                spending = resolution.Spending,
                image = resolution.Image
            };
        }

        public Task<int> Save(ResolutionDTO entityDTO)
        {
            return _resolutionRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(ResolutionDTO entityDTO)
        {
            return _resolutionRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _resolutionRepository.FindById(id);
            return await _resolutionRepository.Delete(entity);
        }
    }
}
