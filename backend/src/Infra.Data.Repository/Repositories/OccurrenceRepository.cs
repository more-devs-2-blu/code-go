using Domain.Entities;
using Domain.Enums;
using Domain.Interfeces.IRepositories;
using Infra.Data.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repositories
{
    public class OccurrenceRepository : BaseRepository<Occurrence>, IOccurrenceRepository
    {
        private readonly MySqlContext _context;

        public OccurrenceRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Occurrence> GetAllByPersonId(int personId)
        {
            return _context.Set<Occurrence>()
                .Where(occurrence => occurrence.IdPerson == personId);
        }

        public IQueryable<Occurrence> GetAllByStatus(StatusEnum status)
        {
            return _context.Set<Occurrence>()
                .Where(occurrence => occurrence.Status == status);
        }
    }
}
