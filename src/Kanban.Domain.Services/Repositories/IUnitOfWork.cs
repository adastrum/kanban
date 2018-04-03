using System;

namespace Kanban.Domain.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
