using Domain.Entities;
using Persistance.Abstractions.Pastes;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concrete.Repositories.Pastes
{
    public class PasteReadRepository : ReadRepository<Paste>, IPasteReadRepository
    {
        public PasteReadRepository(PastelinkDBContext context) : base(context)
        {
        }
    }
}
