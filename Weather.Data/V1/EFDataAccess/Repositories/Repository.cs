using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Weather.Data.V1
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbset;
        private DbContext _dataContext;
        private string Prefix;

        public List<Task> ListEsTask = new List<Task>();

        public Repository(DbContext dataContext, string prefix)
        {
            Prefix = prefix;
            _dataContext = dataContext;
            _dbset = _dataContext.Set<T>();

        }

        protected IDatabaseFactory DatabaseFactory { get; }

        protected DbContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.GetDbContext());

        public List<Task> GetAllTask()
        {
            return ListEsTask;
        }
        public virtual IQueryable<T> SqlQuery(string sql, params object[] parameters)
        {
            return _dbset.FromSql(sql, parameters);
        }
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dataContext.Database.ExecuteSqlCommand(sql, parameters);
        }
        public virtual Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return _dataContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual T Find(params object[] id)
        {
            return _dbset.Find(id);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public virtual Task<T> FindAsync(params object[] id)
        {
            return _dbset.FindAsync(id);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<T> FindNoTrackAsync(params object[] id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity == null) return entity;
            _dataContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual bool Any(params object[] id)
        {
            var entity = _dbset.Find(id);
            if (entity == null) return false;
            _dataContext.Entry(entity).State = EntityState.Detached;
            return true;
        }



        public virtual async Task<bool> AnyAsync(params object[] id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity == null) return false;
            _dataContext.Entry(entity).State = EntityState.Detached;
            return true;
        }

        public virtual int Count()
        {
            return _dbset.Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.AsNoTracking().Where(predicate);
            return objects.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbset.CountAsync();
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.AsNoTracking().Where(predicate);
            return objects.CountAsync();
        }

        public virtual long LongCount()
        {
            return _dbset.LongCount();
        }

        public virtual long LongCount(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.AsNoTracking().Where(predicate);
            return objects.LongCount();
        }

        public virtual Task<long> LongCountAsync()
        {
            return _dbset.LongCountAsync();
        }

        public virtual Task<long> LongCountAsync(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.AsNoTracking().Where(predicate);
            return objects.LongCountAsync();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.IndexAsync(entity));
            // #endregion
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.IndexAsync(entity));

            // #endregion
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.Where(predicate).FirstOrDefault();
            if (objects != null)
            {
                _dbset.Remove(objects);

                // #region Index ES

                // var esNodeRepository = new EsNodeRepository<T>(Prefix);
                // ListEsTask.Add(esNodeRepository.DeleteAsync(objects));

                // #endregion
            }
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            //foreach (var entity in entities)
            //{
            //    _dbset.Add(entity);
            //}
            var enumerable = entities as T[] ?? entities.ToArray();
            _dbset.AddRange(enumerable);

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.IndexAsync(enumerable.ToList()));

            // #endregion
        }

        public virtual void AddRange(params T[] entities)
        {
            _dbset.AddRange(entities);

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.IndexAsync(entities.ToList()));

            // #endregion
        }

        public virtual void DeleteRange(params T[] entities)
        {
            _dbset.RemoveRange(entities);

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.DeleteAsync(entities.ToList()));

            // #endregion
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            _dbset.RemoveRange(enumerable);

            // #region Index ES

            // var esNodeRepository = new EsNodeRepository<T>(Prefix);
            // ListEsTask.Add(esNodeRepository.DeleteAsync(enumerable.ToList()));

            // #endregion
        }

        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var objects = _dbset.Where(predicate);
            if (objects.Any())
            {
                _dbset.RemoveRange(objects);

                // #region Index ES

                // var esNodeRepository = new EsNodeRepository<T>(Prefix);
                // ListEsTask.Add(esNodeRepository.DeleteAsync(objects.ToList()));

                // #endregion
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int Count = 0, string includeProperties = "")
        {
            var query = filter != null ? _dbset.Where(filter) : _dbset;
            if (!String.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (Count > 0)
            {
                query = query.Take(Count);
            }
            return query;
        }

        public virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            // _dbset.Where(predicate);
            IQueryable<T> queryable = GetAll();
            queryable = predicate != null ? _dbset.Where(predicate) : _dbset;

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        /// <summary>
        /// Gets the <see cref="IPagedList{TEntity}"/> based on a predicate, orderby delegate and page information. This method default no-tracking query.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="include">A function to include navigation properties</param>
        /// <param name="pageIndex">The index of page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbset;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
        public virtual DbSet<T> DbSet()
        {
            return _dbset;
        }

        #region  GetPage 

        public virtual Pagination<T> GetPage(PaginationRequest query)
        {
            var dataSet = _dbset.AsNoTracking().AsQueryable();
            query.Page = query.Page ?? 1;
            if (query.Sort != null && query.Size.HasValue)
            {
                dataSet = dataSet.ApplySorting(query.Sort);
                var totals = dataSet.Count();
                var totalsPages = (int)Math.Ceiling(totals / (float)query.Size.Value);
                var excludedRows = (query.Page.Value - 1) * query.Size.Value;
                var items = dataSet.Skip(excludedRows).Take(query.Size.Value + 1).ToList();
                return new Pagination<T>
                {
                    Page = query.Page.Value,
                    Content = items,
                    NumberOfElements = items.Count,
                    Size = query.Size.Value,
                    TotalPages = totalsPages,
                    TotalElements = totals
                };
            }

            if (!query.Size.HasValue)
            {
                var items = dataSet.ToList();

                var totals = dataSet.Count();
                return new Pagination<T>
                {
                    Page = 1,
                    Content = items,
                    NumberOfElements = totals,
                    Size = totals,
                    TotalPages = 1,
                    TotalElements = totals
                };
            }

            return null;
        }

        public virtual Pagination<T> GetPage()
        {
            return GetPage(new PaginationRequest { Size = null });
        }

        public virtual Pagination<T> GetPage(Expression<Func<T, bool>> predicate, PaginationRequest query)
        {
            var dataSet = _dbset.AsQueryable().AsNoTracking().Where(predicate);
            query.Page = query.Page ?? 1;
            if (query.Sort != null && query.Size.HasValue)
            {
                dataSet = dataSet.ApplySorting(query.Sort);
                var totals = dataSet.Count();
                var totalsPages = (int)Math.Ceiling(totals / (float)query.Size.Value);
                var excludedRows = (query.Page.Value - 1) * query.Size.Value;
                var items = dataSet.Skip(excludedRows).Take(query.Size.Value + 1).ToList();
                return new Pagination<T>
                {
                    Page = query.Page.Value,
                    Content = items,
                    NumberOfElements = items.Count,
                    Size = query.Size.Value,
                    TotalPages = totalsPages,
                    TotalElements = totals
                };
            }

            if (!query.Size.HasValue)
            {
                var totals = dataSet.Count();
                var items = dataSet.ToList();
                return new Pagination<T>
                {
                    Page = 1,
                    Content = items,
                    NumberOfElements = totals,
                    Size = totals,
                    TotalPages = 1,
                    TotalElements = totals
                };
            }

            return null;
        }

        public virtual IQueryable<T> GetPageMany(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNum = 0, int pageSize = 20)
        {
            if (pageSize <= 0) pageSize = 20;
            var query = filter != null ? _dbset.Where(filter) : _dbset;
            ////Total result count
            //rowsCount = resetSet.Count();

            ////If page number should be > 0 else set to first page
            //if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

            //Calculate nunber of rows to skip on pagesize
            int excludedRows = (pageNum - 1) * (pageSize - 1);
            if (excludedRows <= 0) excludedRows = 0;

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            //Skip the required rows for the current page and take the next records of pagesize count
            return query.Skip(excludedRows).Take(pageSize);
        }

        public virtual async Task<Pagination<T>> GetPageAsync(PaginationRequest query)
        {
            var dataSet = _dbset.AsNoTracking().AsQueryable();
            query.Page = query.Page ?? 1;
            if (query.Sort != null && query.Size.HasValue)
            {
                dataSet = dataSet.ApplySorting(query.Sort);
                var totals = await dataSet.CountAsync();
                var totalsPages = (int)Math.Ceiling(totals / (float)query.Size.Value);
                var excludedRows = (query.Page.Value - 1) * query.Size.Value;
                var items = await dataSet.Skip(excludedRows).Take(query.Size.Value + 1).ToListAsync();
                return new Pagination<T>
                {
                    Page = query.Page.Value,
                    Content = items,
                    NumberOfElements = items.Count,
                    Size = query.Size.Value,
                    TotalPages = totalsPages,
                    TotalElements = totals
                };
            }

            if (!query.Size.HasValue)
            {
                var items = await dataSet.ToListAsync();
                var totals = await dataSet.CountAsync();
                return new Pagination<T>
                {
                    Page = 1,
                    Content = items,
                    NumberOfElements = totals,
                    Size = totals,
                    TotalPages = 1,
                    TotalElements = totals
                };
            }

            return null;
        }

        public virtual async Task<Pagination<T>> GetPageAsync()
        {
            return await GetPageAsync(new PaginationRequest { Size = null });
        }

        public virtual async Task<Pagination<T>> GetPageAsync(Expression<Func<T, bool>> predicate,
            PaginationRequest query)
        {
            var dataSet = _dbset.AsQueryable().AsNoTracking().Where(predicate);
            query.Page = query.Page ?? 1;
            if (query.Sort != null && query.Size.HasValue)
            {
                dataSet = dataSet.ApplySorting(query.Sort);
                var totals = await dataSet.CountAsync();
                var totalsPages = (int)Math.Ceiling(totals / (float)query.Size.Value);
                var excludedRows = (query.Page.Value - 1) * query.Size.Value;
                dataSet = dataSet.Skip(excludedRows).Take(query.Size.Value + 1);
                var items = dataSet.ToList();
                return new Pagination<T>
                {
                    Page = query.Page.Value,
                    Content = items,
                    NumberOfElements = items.Count(),
                    Size = query.Size.Value,
                    TotalPages = totalsPages,
                    TotalElements = totals
                };
            }

            if (!query.Size.HasValue)
            {
                var totals = await dataSet.CountAsync();
                var items = await dataSet.ToListAsync();
                return new Pagination<T>
                {
                    Page = 1,
                    Content = items,
                    NumberOfElements = totals,
                    Size = totals,
                    TotalPages = 1,
                    TotalElements = totals
                };
            }

            return null;
        }

        #endregion
    }
}