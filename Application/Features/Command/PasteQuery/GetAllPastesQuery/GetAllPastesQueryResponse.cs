﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteQuery.GetAllPastesQuery
{
    public class GetAllPastesQueryResponse
    {
        public List<Paste> Pastes { get; set; }
    }
}