using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfeces.IRepositories
{
    public interface IOccurrenceRepository : IBaseRepository<Occurrence>
    {

        IQueryable<Occurrence> GetAllByPersonId(int personId);
        IQueryable<Occurrence> GetAllByStatus(StatusEnum status);
    }
}
