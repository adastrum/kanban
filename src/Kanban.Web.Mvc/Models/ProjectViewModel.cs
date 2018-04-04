using System.Collections.Generic;
using Kanban.Domain.Model.Entities;

namespace Kanban.Web.Mvc.Models
{
    public class ProjectViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        public List<ProjectTaskViewModel> Tasks { get; set; }
    }
}
