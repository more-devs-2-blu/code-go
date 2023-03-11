using Domain.Entities;
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
        public OccurrenceRepository(MySqlContext context) : base(context)
        {
        }
    }
}
