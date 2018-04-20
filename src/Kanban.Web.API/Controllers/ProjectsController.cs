using System;
using AutoMapper;
using Kanban.Application.Services.Filters;
using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Services;
using Kanban.Web.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Web.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public IActionResult GetProjects([FromQuery]ProjectFilter filter)
        {
            return Ok(_projectService.Get(filter));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProjectById(Guid id)
        {
            var project = _projectService.FindById(id);

            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] CreateProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _mapper.Map<CreateProjectModel, Project>(model);
            _projectService.Create(project);

            return CreatedAtAction(nameof(GetProjectById), new { project.Id }, project);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] UpdateProjectModel model)
        {
            var project = _projectService.FindById(id);
            if (project == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(model, project);
            _projectService.Update(project);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var project = _projectService.FindById(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectService.Remove(project);

            return NoContent();
        }
    }
}
