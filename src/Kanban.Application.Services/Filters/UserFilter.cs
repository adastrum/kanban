using System;
using System.Linq.Expressions;
using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Services;
using Kanban.SharedKernel;

namespace Kanban.Application.Services.Filters
{
    public class UserFilter : IFilter<User>
    {
        public string Name { get; set; }

        public Expression<Func<User, bool>> GetExpression()
        {
            Expression<Func<User, bool>> expression = null;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                expression = expression.And(x => x.Name.Contains(Name));
            }

            return expression ?? PredicateBuilder.True<User>();
        }
    }
}
