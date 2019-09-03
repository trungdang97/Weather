using System;
using System.Threading;
using System.Threading.Tasks;

namespace Weather.Data.V1
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
        bool CheckConnection();
    }
}