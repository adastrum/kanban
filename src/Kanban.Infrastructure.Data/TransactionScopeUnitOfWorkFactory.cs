using System.Transactions;
using Kanban.Domain.Services.Repositories;

namespace Kanban.Infrastructure.Data
{
    public class TransactionScopeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            //todo: different isolation levels
            return new TransactionScopeUnitOfWork(IsolationLevel.ReadCommitted);
        }
    }
}
