using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Resolution
    {
        public int Id { get; set; }
        public int IdOccurrence { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? Spending { get; set; }
        public string? Image { get; set; }

        public virtual Occurrence Occurrence { get; set; }
    }
}
