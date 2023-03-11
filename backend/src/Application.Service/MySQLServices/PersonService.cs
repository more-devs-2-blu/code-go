using Domain.DTO;
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
        private readonly PersonDTO _personDTO;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _personDTO = new PersonDTO();
        }

        public List<PersonDTO> FindAll()
        {
            return _personRepository.FindAll()
                .Select(x => _personDTO.MapToDTO(x))
                                       .ToList();
        }

        public async Task<PersonDTO> FindById(int id)
        {
            return _personDTO.MapToDTO(await _personRepository.FindById(id));
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
