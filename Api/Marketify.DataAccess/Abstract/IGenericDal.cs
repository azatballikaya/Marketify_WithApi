using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T,bool>> filter,Func<IQueryable<T>,IIncludableQueryable<T,object>> include=null);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter=null,Func<IQueryable<T>,IIncludableQueryable<T,object>> include=null);
    }
}
