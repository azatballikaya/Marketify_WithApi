using Marketify.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.Concrete.EntityFramework
{
    public  class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly IdentityContext _context;
        public GenericRepository(IdentityContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

      

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include=null)
        {
            IQueryable<T> query=_context.Set<T>();
            if(include!=null)
            {
                query=include(query);
            }
           
           
                return await query.FirstOrDefaultAsync(filter);
            
           
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter=null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include=null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }
            if (filter != null)
            {
               query= query.Where(filter);
            }
            
            return await  query.ToListAsync();
        }

       

       

        public async Task InsertAsync(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();  
        }

       

        public async Task UpdateAsync(T entity)
        {
             _context.Set<T>().Update(entity);  
          await  _context.SaveChangesAsync();
        }

       
    }
}
