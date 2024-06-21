using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Abstractions
{
    public interface IReadRepository<T>:IBaseRepository<T> where T : class
    {
        Task<T> GetById(string id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
    }
}
