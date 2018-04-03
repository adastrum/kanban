using System;
using System.Linq.Expressions;
using Kanban.SharedKernel;

namespace Kanban.Domain.Services.Services
{
    public interface IFilter<T>
        where T: Entity
    {
        Expression<Func<T, bool>> GetExpression();
    }
}
