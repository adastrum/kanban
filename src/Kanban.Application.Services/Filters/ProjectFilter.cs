using System;
using System.Linq.Expressions;
using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Services;
using Kanban.SharedKernel;

namespace Kanban.Application.Services.Filters
{
    public class ProjectFilter : IFilter<Project>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectStatus? Status { get; set; }

        public Expression<Func<Project, bool>> GetExpression()
        {
            Expression<Func<Project, bool>> expression = null;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                expression = expression.And(x => x.Name.Contains(Name));
            }

            if (Status.HasValue)
            {
                expression = expression.And(x => x.Status == Status);
            }

            return expression ?? PredicateBuilder.True<Project>();
        }
    }
}
