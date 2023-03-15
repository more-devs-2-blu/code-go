using Domain.DTO;
using Domain.Entities;
using Domain.Enums;
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
        private readonly IAddressRepository _addressRepository;

        public OccurrenceService(IOccurrenceRepository occurrenceRepository,
                                 IAddressRepository addressRepository)
        {
            _occurrenceRepository = occurrenceRepository;
            _addressRepository = addressRepository;
        }

        public List<OccurrenceDTO> FindAll()
        {
            return _occurrenceRepository.FindAll()
                .Select(x => new OccurrenceDTO()
                {
                    id = x.Id,
                    idPerson = x.IdPerson,
                    idAddress = x.IdAddress,
                    status = x.Status,
                    createdOn = x.CreatedOn,
                    expectedDate = x.ExpectedDate,
                    frequency = x.Frequency,
                    image = x.Image,
                    address = new AddressDTO()
                    {
                        id = x.Address.Id,
                        street = x.Address.Street,
                        number = x.Address.Number,
                        district = x.Address.District,
                        city = x.Address.City,
                        state = x.Address.State
                    }
                }).ToList();
        }

        public List<OccurrenceDTO> GetAllByPersonId(int personId)
        {
            return _occurrenceRepository.FindAll()
                .Select(x => new OccurrenceDTO()
                {
                    id = x.Id,
                    idPerson = x.IdPerson,
                    idAddress = x.IdAddress,
                    status = x.Status,
                    createdOn = x.CreatedOn,
                    expectedDate = x.ExpectedDate,
                    frequency = x.Frequency,
                    image = x.Image,
                    address = new AddressDTO()
                    {
                        id = x.Address.Id,
                        street = x.Address.Street,
                        number = x.Address.Number,
                        district = x.Address.District,
                        city = x.Address.City,
                        state = x.Address.State
                    }
                }).ToList();
        }

        public List<OccurrenceDTO> GetAllByStatus(StatusEnum status)
        {
            throw new NotImplementedException();
        }


        public async Task<OccurrenceDTO> FindById(int id)
        {
            Occurrence occurrence = await _occurrenceRepository.FindById(id);
            Address address = await _addressRepository.FindById(occurrence.IdAddress);

            return new OccurrenceDTO()
            {
                id = occurrence.Id,
                idPerson = occurrence.IdPerson,
                idAddress = occurrence.IdAddress,
                status = occurrence.Status,
                createdOn = occurrence.CreatedOn,
                expectedDate = occurrence.ExpectedDate,
                frequency = occurrence.Frequency,
                image = occurrence.Image,
                address = new AddressDTO()
                {
                    id = address.Id,
                    street = address.Street,
                    number = address.Number,
                    district = address.District,
                    city = address.City,
                    state = address.State
                }
            };
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

        public Task<OccurrenceDTO> FindByIdPerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
