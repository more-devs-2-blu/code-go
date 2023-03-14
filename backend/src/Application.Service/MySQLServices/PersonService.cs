using Domain.DTO;
using Domain.Entities;
using Domain.Interfeces.IRepositories;
using Domain.Interfeces.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MySQLServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly PersonDTO _personDTO;

        public PersonService(IPersonRepository personRepository,
                             IOccurrenceRepository occurrenceRepository)
        {
            _personRepository = personRepository;
            _occurrenceRepository = occurrenceRepository;
            _personDTO = new PersonDTO();
        }

        public List<PersonDTO> FindAll()
        {
            return _personRepository.FindAll()
                .Select(x => new PersonDTO()
                {
                    id = x.Id,
                    name = x.Name,
                    birth = x.Birth,
                    email = x.Email,
                    password = x.Password,
                    phone = x.Phone,
                    createdOn = x.CreatedOn,
                    cpf = x.CPF,
                    type = x.Type,
                    occurrences = x.Occurrences
                    .Select(occurrence => new OccurrenceDTO()
                    {
                        id = occurrence.Id,
                        idPerson = occurrence.IdPerson,
                        idAddress = occurrence.IdAddress,
                        createdOn = occurrence.CreatedOn,
                        expectedDate = occurrence.ExpectedDate,
                        status = occurrence.Status,
                        frequency = occurrence.Frequency,
                        image = occurrence.Image,
                        address = new AddressDTO()
                        {
                            id = occurrence.Address.Id,
                            street = occurrence.Address.Street,
                            number = occurrence.Address.Number,
                            district = occurrence.Address.District,
                            city = occurrence.Address.City,
                            state = occurrence.Address.State
                        }
                    }).ToList()
                }).ToList();
        }

        public async Task<PersonDTO> FindById(int id)
        {
            Person person = await _personRepository.FindById(id);
            IQueryable<Occurrence> occurrencesEntity = _occurrenceRepository.GetAllByPersonId(person.Id);

            return new PersonDTO()
            {
                id = person.Id,
                name = person.Name,
                birth = person.Birth,
                email = person.Email,
                password = person.Password,
                phone = person.Phone,
                createdOn = person.CreatedOn,
                cpf = person.CPF,
                type = person.Type,
                occurrences = occurrencesEntity
                .Select(occurrence => new OccurrenceDTO()
                {
                    id = occurrence.Id,
                    idPerson = occurrence.IdPerson,
                    idAddress = occurrence.IdAddress,
                    createdOn = occurrence.CreatedOn,
                    expectedDate = occurrence.ExpectedDate,
                    frequency = occurrence.Frequency,
                    status = occurrence.Status,
                    image = occurrence.Image,
                    address = new AddressDTO()
                    {
                        id = occurrence.Address.Id,
                        city = occurrence.Address.City,
                        district = occurrence.Address.District,
                        number = occurrence.Address.Number,
                        state = occurrence.Address.State,
                        street = occurrence.Address.Street
                    }
                }).ToList()
            };
        }

        public Task<int> Save(PersonDTO entityDTO)
        {
            return _personRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(PersonDTO entityDTO)
        {
            return _personRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _personRepository.FindById(id);
            return await _personRepository.Delete(entity);
        }
    }
}
