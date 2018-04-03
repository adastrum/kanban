using System;
using Kanban.SharedKernel;

namespace Kanban.Domain.Services.Services
{
    public interface ICrudService<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity item);

        TEntity FindById(Guid id);

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}
