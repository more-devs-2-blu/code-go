using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AddressDTO
    {
        public int id { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }


        #region Methods
        public Address MapToEntity()
        {
            return new Address()
            {
                Id = id,
                Street = street,
                Number = number,
                District = district,
                City = city,
                State = state
            };
        }

        public AddressDTO MapToDTO(Address address)
        {
            return new AddressDTO()
            {
                id = address.Id,
                street = address.Street,
                number = address.Number,
                district = address.District,
                city = address.City,
                state = address.State
            };
        }
        #endregion
    }
}
