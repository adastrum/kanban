using System.Collections.Generic;
using Kanban.SharedKernel;

namespace Kanban.Domain.Model.Entities
{
    public class Project : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        public List<ProjectTask> Tasks { get; set; }
    }

    public enum ProjectStatus
    {
        Active,
        Inactive
    }
}
