using System;
namespace Weather.Data.V1
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing) DisposeEf();

            _isDisposed = true;
        }

        protected virtual void DisposeEf()
        {
        }
    }
}