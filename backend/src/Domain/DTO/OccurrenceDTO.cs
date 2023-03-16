using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class OccurrenceDTO
    {
        public int id { get; set; }
        public int idPerson { get; set; }
        public int idAddress { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime? expectedDate { get; set; }
        public StatusEnum status { get; set; }
        public int frequency { get; set; }
        public string? image { get; set; }
        public CategoryEnum category { get; set; }

        public string? desciption { get; set; }
        public virtual AddressDTO? address { get; set; }
        public virtual ResolutionDTO? Resolution { get; set; }

        #region Methods
        public Occurrence MapToEntity()
        {
            return new Occurrence()
            {
                Id = id,
                IdPerson = idPerson,
                IdAddress = idAddress,
                CreatedOn = createdOn,
                ExpectedDate = expectedDate,
                Status = status,
                Desciption = desciption,
                Category = category,
                Frequency = frequency,
                Image = image
            };
        }

        public OccurrenceDTO MapToDTO(Occurrence occurrence)
        {
            return new OccurrenceDTO()
            {
                id = occurrence.Id,
                idPerson = occurrence.IdPerson,
                idAddress = occurrence.IdAddress,
                createdOn = occurrence.CreatedOn,
                expectedDate = occurrence.ExpectedDate,
                status = occurrence.Status,
                category = occurrence.Category, 
                desciption = occurrence.Desciption,
                frequency = occurrence.Frequency,
                image = occurrence.Image
            };
        }
        #endregion
    }
}
