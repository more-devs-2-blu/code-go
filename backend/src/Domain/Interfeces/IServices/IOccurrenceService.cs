﻿using Domain.DTO;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfeces.IServices
{
    public interface IOccurrenceService : IBaseService<OccurrenceDTO>
    {
        List<OccurrenceDTO> GetAllByPersonId(int personId);
        List<OccurrenceDTO> GetAllByStatus(StatusEnum status);
    }
}
