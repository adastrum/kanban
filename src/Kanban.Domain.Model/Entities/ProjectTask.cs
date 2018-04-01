using System;
using Kanban.SharedKernel;

namespace Kanban.Domain.Model.Entities
{
    public class ProjectTask : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public Guid ReporterId { get; set; }

        public User Reporter { get; set; }

        public Guid AssigneeId { get; set; }

        public User Assignee { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public ProjectTaskStatus Status { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }
    }

    public enum ProjectTaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}