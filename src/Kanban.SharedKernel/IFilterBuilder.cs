using System;
using System.Linq.Expressions;

namespace Kanban.SharedKernel
{
    public interface IFilterBuilder<T>
    {
        Expression<Func<T, bool>> Build();
    }
}
