using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        #region DbSets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Occurrence> Occurrences { get; set;}
        public DbSet<Person> People { get; set; }
        #endregion
    }
}
