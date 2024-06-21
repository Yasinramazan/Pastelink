using Domain.Entities;

using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class PastelinkDBContext: IdentityDbContext<AppUser,AppRole,string>
    {
        
        public PastelinkDBContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Paste> Pastes { get; set; }

        public override int SaveChanges()
        {

            var datas = ChangeTracker.Entries<Paste>();

            foreach (var item in datas)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedTime = DateTime.UtcNow;
                    item.Entity.IsLocked = false;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.UtcNow;
                }
                
            }

            return base.SaveChanges();
        }
    }
}
