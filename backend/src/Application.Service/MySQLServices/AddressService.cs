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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly AddressDTO _addressDTO;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            _addressDTO = new AddressDTO();
        }

        public List<AddressDTO> FindAll()
        {
            return _addressRepository.FindAll()
                .Select(x => _addressDTO.MapToDTO(x))
                                       .ToList();
        }

        public async Task<AddressDTO> FindById(int id)
        {
            return _addressDTO.MapToDTO(await _addressRepository.FindById(id));
        }

        public Task<int> Save(AddressDTO entityDTO)
        {
            return _addressRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(AddressDTO entityDTO)
        {
            return _addressRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _addressRepository.FindById(id);
            return await _addressRepository.Delete(entity);
        }
    }
}
