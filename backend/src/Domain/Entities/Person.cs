using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CPF { get; set; }
        public PersonTypeEnum Type { get; set; } 

        public virtual ICollection<Occurrence>? Occurrences { get; set; }
    }
}
