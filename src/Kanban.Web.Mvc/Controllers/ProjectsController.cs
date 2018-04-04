using Kanban.Domain.Services.Services;
using Kanban.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Web.Mvc.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ActionResult Index(ProjectsIndexViewModel model)
        {
            var filter = model.Filter;
            //todo: map filter model to filter, get projects, map projects to project models
            return View(model);
        }
    }
}