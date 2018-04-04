using Kanban.Domain.Model.Entities;

namespace Kanban.Web.Mvc.Models.Filters
{
    public class ProjectFilterViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectStatus? Status { get; set; }
    }
}
