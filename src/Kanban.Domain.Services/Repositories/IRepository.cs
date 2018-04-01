using System;
using System.Collections.Generic;
using Kanban.SharedKernel;

namespace Kanban.Domain.Services.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity item);

        TEntity FindById(Guid id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}
