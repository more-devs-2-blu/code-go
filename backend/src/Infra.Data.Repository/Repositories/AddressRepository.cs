using Domain.Entities;
using Domain.Interfeces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
    }
}
