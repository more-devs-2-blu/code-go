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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySqlContext context) : base(context)
        {
        }
    }
}
