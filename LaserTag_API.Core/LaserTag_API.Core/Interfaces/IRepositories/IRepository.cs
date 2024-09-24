using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Query;

namespace LaserTag_API.Core.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(string id);
        /*Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);*/
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
