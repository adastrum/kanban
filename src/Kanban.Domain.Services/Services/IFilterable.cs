using System.Collections.Generic;
using Kanban.SharedKernel;

namespace Kanban.Domain.Services.Services
{
    public interface IFilterable<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> Get(IFilter<TEntity> filter);
    }
}
