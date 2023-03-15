using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ResolutionDTO
    {
        public int id { get; set; }
        public int idOccurrence { get; set; }
        public string description { get; set; }
        public DateTime createdOn { get; set; }
        public string? spending { get; set; }
        public string? image { get; set; }

        #region Methods
        public Resolution MapToEntity()
        {
            return new Resolution()
            {
                Id = id,
                IdOccurrence = idOccurrence,
                Description = description,
                CreatedOn = createdOn,
                Spending = spending,
                Image = image
            };
        }

        public ResolutionDTO MapToDTO(Resolution resolution)
        {
            return new ResolutionDTO()
            {
                id = resolution.Id,
                idOccurrence = resolution.IdOccurrence,
                description = resolution.Description,
                createdOn = resolution.CreatedOn,
                spending = resolution.Spending,
                image = resolution.Image
            };
        }
        #endregion
    }
}
