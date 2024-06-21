using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Persistance.Abstractions.Pastes;
using Persistance.Concrete.Repositories.Pastes;
using Microsoft.AspNetCore.Http;

namespace Persistance   
{
    public static class ServiceRegistration
    {
        
        public static void AddPersistenceService(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.AddJsonFile("AppSettings.json");
            services.AddDbContext<PastelinkDBContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("MSSql")));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<PastelinkDBContext>();
            services.AddScoped<IPasteWriteRepository,PasteWriteRepository>();
            services.AddScoped<IPasteReadRepository,PasteReadRepository>();
            
            

        }
    }
}
