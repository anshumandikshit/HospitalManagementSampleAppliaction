using HospitalManagement.DB;
using HospitalManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //public DbContext Context
        //{
        //    get
        //    {
        //        return _context;
        //    }
        //}

        protected HospitalManagementContext _context;
        protected DbSet<T> DbSet;
        public GenericRepository(HospitalManagementContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            //var result =await DbSet.FindAsync(id);
            //Console.WriteLine(result);
            return await DbSet.FindAsync(id);

        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.FirstOrDefault();
            else
                return DbSet.FirstOrDefault(predicate);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await DbSet.FirstOrDefaultAsync();
            else
                return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FirstOrDefaultWithIncludeAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = DbSet;

            if (include != null)
                query = include(query);

            if (predicate == null)
                return await query.FirstOrDefaultAsync();
            else
                return await query.FirstOrDefaultAsync(predicate);
        }
        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.Count();
            else
                return DbSet.Count(predicate);
        }
        public bool Any(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.Any();
            else
                return DbSet.Any(predicate);
        }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            DbSet.Remove(entity);
            return entity;
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        

        public async virtual Task<List<T>> FindWithIncludeAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           int? start = null, int? length = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (start.HasValue)
            {
                query = query.Skip(start.Value);
            }
            if (length.HasValue)
            {
                query = query.Take(length.Value);
            }
            return await query.ToListAsync();
        }

        public async virtual Task<List<TType>> FindWithIncludeAsync<TType>(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           int? start = null, int? length = null, bool disableTracking = true, Expression<Func<T, TType>> select = null)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (start.HasValue)
            {
                query = query.Skip(start.Value);
            }
            if (length.HasValue)
            {
                return await query.Take(length.Value).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }

        }

    }
}
