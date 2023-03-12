using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PersonDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birth { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime createdOn { get; set; }
        public string cpf { get; set; }
        public PersonTypeEnum type { get; set; }

        //public virtual ICollection<OccurrenceDTO>? occurrences { get; set; }


        #region Methods
        public Person MapToEntity()
        {
            return new Person()
            {
                Id = id,
                Name = name,
                Birth = birth,
                Email = email,
                Password = password,
                Phone = phone,
                CreatedOn = createdOn,
                CPF = cpf,
                Type = type
            };
        }

        public PersonDTO MapToDTO(Person person)
        {
            OccurrenceDTO occurrenceDTO = new OccurrenceDTO();
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
                type = person.Type
            };
        }
        #endregion
    }
}
