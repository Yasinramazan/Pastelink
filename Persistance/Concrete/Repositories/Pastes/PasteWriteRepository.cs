using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Abstractions;
using Persistance.Abstractions.Pastes;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concrete.Repositories.Pastes
{
    public class PasteWriteRepository : WriteRepository<Paste>, IPasteWriteRepository
    {
        public PasteWriteRepository(PastelinkDBContext context) : base(context)
        {
        }
    }
}
