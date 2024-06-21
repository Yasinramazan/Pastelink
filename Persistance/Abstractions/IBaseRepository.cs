using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> Table();

    }
}
