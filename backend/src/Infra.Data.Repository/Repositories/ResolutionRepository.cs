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
    public class ResolutionRepository : BaseRepository<Resolution>, IResolutionRepository
    {
        public ResolutionRepository(MySqlContext context) : base(context)
        {
            
        }
    }
}
