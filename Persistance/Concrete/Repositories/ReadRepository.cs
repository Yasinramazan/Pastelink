using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Abstractions;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concrete.Repositories
{
    public class ReadRepository<T> : IReadRepository<T>where T : Paste
    {
        private readonly PastelinkDBContext _context;

        public ReadRepository(PastelinkDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(string id)
        {
            return await Table().FirstOrDefaultAsync(x=>x.Id.ToString()==id);
        }

        public IEnumerable<T> GetAll()
        {
            return Table();
        }

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
            return Table().Where(method);
        }

        public DbSet<T> Table()
        {
            return _context.Set<T>();
        }
    }
}
