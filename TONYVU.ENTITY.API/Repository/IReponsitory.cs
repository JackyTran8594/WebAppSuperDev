using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public interface IReponsitory : IDisposable
    {
        //IQueryable<T> GetAll();
        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets the unit of work
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        T GetByKey<T>(object keyValue) where T : class;

        /// <summary>
        /// Gets the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetQuery<T>() where T : class;

        /// <summary>
        /// Gets the query
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="predicate">The predicate</param>
        /// <returns></returns>
        IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : class;

        /// <summary>
        /// Gets the specified order by
        /// </summary>
        /// <typeparam name="T">the type of entity</typeparam>
        /// <typeparam name="TOrderBy">the type of the order by</typeparam>
        /// <param name="orderby">the order by</param>
        /// <param name="pageIndex">index of the page</param>
        /// <param name="pageSize">size of the page</param>
        /// <param name="sortOrder">the sort order</param>
        /// <returns></returns>
        IEnumerable<T> Get<T, TOrderBy>(Expression<Func<T, TOrderBy>> orderby, int pageIndex, int pageSize,
            SortOrder sortOrder = SortOrder.Ascending) where T : class;
            /// <summary>
        /// Gets the specified criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOrderBy"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="orderby"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        IEnumerable<T> Get<T, TOrderBy>(Expression<Func<T, bool>> criteria,
            Expression<Func<T, TOrderBy>> orderby, int pageIndex, int pageSize,
            SortOrder sortOrder = SortOrder.Ascending) where T : class;

        /// <summary>
        /// Gets one entity based on matching criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        T Single<T>(Expression<Func<T, bool>> criteria) where T : class;

        /// <summary>
        ///  Firsts the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T First<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Finds entities based on provided criteria.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> criteria) where T : class;

        /// <summary>
        /// Finds one entity based on provided criteria.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        T FindOne<T>(Expression<Func<T, bool>> criteria) where T : class;

        /// <summary>
        /// Counts the specified entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        int Count<T>() where T : class;

        /// <summary>
        /// Counts entities with the specified criteria.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        int Count<T>(Expression<Func<T, bool>> criteria) where T : class;

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Add<T>(T entity) where T : class;


        /// <summary>
        /// Updates changes of the existing entity.
        ///     The caller must later call SaveChanges() 
        ///     on the repository explicitly to save the entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity) where T : class;


        /// <summary>
        ///  Attaches the specified entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Attach<T>(T entity) where T : class;

        /// <summary>
        ///  Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Deletes one or many entities matching the specified criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        void Delete<T>(Expression<Func<T, bool>> criteria) where T : class;

    }


}
