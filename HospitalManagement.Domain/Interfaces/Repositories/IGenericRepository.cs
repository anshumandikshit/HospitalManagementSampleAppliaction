using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {

        //DbContext Context { get; }

        Task<T> GetByIdAsync(object id);

        T GetById(object id);
        /// <summary>
        /// Fetches all the Entities of Type T
        /// </summary>
        /// <returns>All entities present as IEnumerable</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Fetches all the Entities of Type T Asynchronously
        /// </summary>
        /// <returns>All entities present as IEnumerable asynchronously</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Fetches the no of elements present
        /// </summary>
        /// <param name="predicate">Lambda expression representing a condition</param>
        /// <returns>An Integer</returns>
        int Count(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Finds if there are any elements in the List
        /// </summary>
        /// <param name="predicate">Lambda representing the Condition</param>
        /// <returns>Boolean</returns>
        bool Any(Expression<Func<T, bool>> predicate = null);
        /// <summary>
        /// Return the first element or the default if not found
        /// </summary>
        /// <param name="predicate">The predicate for the condition</param>
        /// <returns>The first Element or The default Value</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> FirstOrDefaultWithIncludeAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        /// <summary>
        /// Add an object of Type T to the dataset
        /// </summary>
        /// <param name="entity">The object that requires to be added</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Removes an object of Type T from the dataset
        /// </summary>
        /// <param name="entity">The object that requires to be removed</param>
        /// <returns></returns>
        T Delete(T entity);

        /// <summary>
        /// Attach an Entity to the data set and changes its entity state to Modified
        /// </summary>
        /// <param name="entity">The object that requires to be edited</param>
        /// <returns>Void</returns>
        void Edit(T entity);

       
        Task<List<T>> FindWithIncludeAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           int? start = null, int? length = null, bool disableTracking = true);

        Task<List<TType>> FindWithIncludeAsync<TType>(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           int? start = null, int? length = null, bool disableTracking = true, Expression<Func<T, TType>> select = null);

    }
}
