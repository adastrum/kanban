using System;
using System.Linq.Expressions;
using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Services;
using Kanban.SharedKernel;

namespace Kanban.Application.Services.Filters
{
    /// <summary>
    /// todo
    /// </summary>
    public class ProjectTaskFilter : IFilter<ProjectTask>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public Guid? ReporterId { get; set; }

        public Guid? AssigneeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public ProjectTaskStatus? Status { get; set; }

        public Guid? ProjectId { get; set; }

        public Expression<Func<ProjectTask, bool>> GetExpression()
        {
            Expression<Func<ProjectTask, bool>> expression = null;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                expression = expression.And(x => x.Name.Contains(Name));
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                expression = expression.And(x => x.Description.Contains(Description));
            }

            if (Status.HasValue)
            {
                expression = expression.And(x => x.Status == Status);
            }

            return expression ?? PredicateBuilder.True<ProjectTask>();
        }
    }
}
