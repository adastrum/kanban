using System;
using System.Transactions;
using Kanban.Domain.Services.Repositories;

namespace Kanban.Infrastructure.Data
{
    //todo: System.Transactions are not supported yet in entity framework core
    public class TransactionScopeUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly TransactionScope _transactionScope;

        public TransactionScopeUnitOfWork(IsolationLevel isolationLevel)
        {
            //_transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = isolationLevel });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //_transactionScope.Dispose();
                }

                _disposed = true;
            }
        }

        public void Commit()
        {
            //_transactionScope.Complete();
        }
    }
}
