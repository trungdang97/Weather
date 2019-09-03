using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Weather.Data.V1
{
    public interface IRepositoryBase
    {
        List<Task> GetAllTask();
    }
    public interface IRepository<T> : IRepositoryBase where T : class
    {
        IQueryable<T> SqlQuery(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        T Find(params object[] id);
        T Find(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(params object[] id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindNoTrackAsync(params object[] id);
        bool Any(params object[] id);
        Task<bool> AnyAsync(params object[] id);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        long LongCount();
        long LongCount(Expression<Func<T, bool>> predicate);
        Task<long> LongCountAsync();
        Task<long> LongCountAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        void AddRange(IEnumerable<T> entities);
        void AddRange(params T[] entities);
        void DeleteRange(params T[] entities);
        void DeleteRange(IEnumerable<T> entities);
        void DeleteRange(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> GetMany(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int Count = 0, string includeProperties = "");
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        DbSet<T> DbSet();

        #region  GetPage
        Pagination<T> GetPage(PaginationRequest query);
        Pagination<T> GetPage();
        Pagination<T> GetPage(Expression<Func<T, bool>> predicate, PaginationRequest query);
        IQueryable<T> GetPageMany(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNum = 0, int pageSize = 20);
        Task<Pagination<T>> GetPageAsync(PaginationRequest query);
        Task<Pagination<T>> GetPageAsync();
        Task<Pagination<T>> GetPageAsync(Expression<Func<T, bool>> predicate, PaginationRequest query);
        #endregion
    }
}