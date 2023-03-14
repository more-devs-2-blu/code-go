using Domain.Entities;
using Domain.Enums;
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
            modelBuilder.Entity<Occurrence>()
                .HasOne(occurrence => occurrence.Person)
                .WithMany(person => person.Occurrences)
                .HasForeignKey(occurrence => occurrence.IdPerson);

            modelBuilder.Entity<Occurrence>()
                .HasOne(occurrence => occurrence.Address)
                .WithOne(address => address.Occurrence)
                .HasForeignKey<Occurrence>(occurrence => occurrence.IdAddress);

            modelBuilder.Entity<Person>()
                .HasData(
                    new { Id=1, Name="Admin", Birth=new DateTime(), Email="admin@gmail.com", Password="admin", Phone="47988887777", CreatedOn=DateTime.Now, CPF= "15746546240", Type=PersonTypeEnum.Administrator }
                );
        }

        #region DbSets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Occurrence> Occurrences { get; set;}
        public DbSet<Person> People { get; set; }
        #endregion
    }
}
