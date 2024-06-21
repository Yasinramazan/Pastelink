using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Abstractions
{
    public interface IWriteRepository<T>:IBaseRepository<T> where T : class
    {
        
        Task<bool> Add(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(T model);
        int SaveAsync();
    }
}
