using Kanban.Web.Mvc.Models.Filters;

namespace Kanban.Web.Mvc.Models
{
    public class ProjectsIndexViewModel
    {
        public ProjectsIndexViewModel()
        {
            Filter = new ProjectFilterViewModel();
        }

        public ProjectFilterViewModel Filter { get; set; }
    }
}
