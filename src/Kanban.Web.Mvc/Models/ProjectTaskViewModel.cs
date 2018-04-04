using System;
using Kanban.Domain.Model.Entities;

namespace Kanban.Web.Mvc.Models
{
    public class ProjectTaskViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public UserViewModel Reporter { get; set; }

        public UserViewModel Assignee { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public ProjectTaskStatus Status { get; set; }
    }
}
