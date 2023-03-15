﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Occurrence
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public StatusEnum Status { get; set; }
        public int Frequency { get; set; }
        public string? Image { get; set; }
        public CategoryEnum Category { get; set; }
        public string? Desciption { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Resolution? Resolution { get; set; }
    }
}
