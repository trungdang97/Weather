using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Weather.Data.V1
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private DbContext _dataContext;
        private bool _disposed;
        private string Prefix;
        public List<IRepositoryBase> ListRepository = new List<IRepositoryBase>();


        public UnitOfWork(string prefix = "")
        {
            Prefix = prefix;
            _databaseFactory = new DatabaseFactory(prefix);
            _dataContext = _databaseFactory.GetDbContext();
        }

        public DbContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.GetDbContext());

        public IRepository<T> GetRepository<T>() where T : class
        {
            var repository = new Repository<T>(_dataContext, Prefix);
            ListRepository.Add(repository);
            return repository;
        }

        public int Save()
        {
            var listTask = new List<Task>();
            foreach (var repository in ListRepository)
            {
                listTask.AddRange(repository.GetAllTask());
            }
            if (listTask.Count > 0)
            {
                Task.WaitAll(listTask.ToArray());
            }
            return DataContext.SaveChanges();
        }

        public bool CheckConnection()
        {
            return DataContext.Database.GetDbConnection().State == System.Data.ConnectionState.Connecting;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var listTask = new List<Task>();
            foreach (var repository in ListRepository)
            {
                listTask.AddRange(repository.GetAllTask());
            }
            Console.WriteLine(listTask);
            if (listTask.Count > 0)
            {
                await Task.WhenAll(listTask);
            }

            return await DataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _dataContext.Dispose();
                    _disposed = true;
                }

            _disposed = false;
        }
    }
}