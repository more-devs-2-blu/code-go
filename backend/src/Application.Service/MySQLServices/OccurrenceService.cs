using Domain.DTO;
using Domain.Interfeces.IRepositories;
using Domain.Interfeces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MySQLServices
{
    public class OccurrenceService : IOccurrenceService
    {
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly OccurrenceDTO _occurrenceDTO;

        public OccurrenceService(IOccurrenceRepository occurrenceRepository)
        {
            _occurrenceRepository = occurrenceRepository;
            _occurrenceDTO = new OccurrenceDTO();
        }

        public List<OccurrenceDTO> FindAll()
        {
            return _occurrenceRepository.FindAll()
                .Select(x => _occurrenceDTO.MapToDTO(x))
                                          .ToList();
        }

        public async Task<OccurrenceDTO> FindById(int id)
        {
            return _occurrenceDTO.MapToDTO(await _occurrenceRepository.FindById(id));
        }

        public Task<int> Save(OccurrenceDTO entityDTO)
        {
            return _occurrenceRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(OccurrenceDTO entityDTO)
        {
            return _occurrenceRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _occurrenceRepository.FindById(id);
            return await _occurrenceRepository.Delete(entity);
        }
    }
}
