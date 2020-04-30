using System;
using System.Data.Entity;

namespace VAT
{
    public class UnityOfWork : IUnityOfWork
    {
        private DbContext _dbContext;
        public UnityOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public DbContext DbContext { get => _dbContext; set => _dbContext = value; }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
