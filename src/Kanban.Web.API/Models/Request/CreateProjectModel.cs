using Kanban.Domain.Model.Entities;

namespace Kanban.Web.API.Models.Request
{
    public class CreateProjectModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
