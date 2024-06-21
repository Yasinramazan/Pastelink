using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistance.Abstractions;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concrete.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private PastelinkDBContext _context;

        public WriteRepository(PastelinkDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T model)
        {
           EntityEntry<T> entry = await Table().AddAsync(model);
           return entry.State== EntityState.Added;
        }

        public async Task<bool> Delete(T model) 
        {
            EntityEntry<T> entry =  Table().Remove(model);
            return entry.State == EntityState.Added;
        }

        public int SaveAsync()
        =>   _context.SaveChanges();

        public DbSet<T> Table()
        {
            return _context.Set<T>();
        }

        public async Task<bool> Update(T model)
        {
            _context.ChangeTracker.Clear();
            EntityEntry<T> entry = Table().Update(model);
            return entry.State == EntityState.Modified;
        }
    }
}
