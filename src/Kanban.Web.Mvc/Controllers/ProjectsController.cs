using System.Linq;
using AutoMapper;
using Kanban.Application.Services.Filters;
using Kanban.Domain.Services.Services;
using Kanban.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Web.Mvc.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public ProjectsController(
            IMapper mapper,
            IProjectService projectService
        )
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        public ActionResult Index(ProjectsIndexViewModel model)
        {
            var filter = _mapper.Map<ProjectFilter>(model.Filter);
            var projects = _projectService.Get(filter);
            model.Projects = projects
                .Select(x => _mapper.Map<ProjectViewModel>(x))
                .ToList();
            return View(model);
        }
    }
}