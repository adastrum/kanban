using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kanban.Application.Services.Filters;
using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Services;
using Kanban.Web.API.Models.Request;
using Kanban.Web.API.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Web.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        [ProducesResponseType(200, Type = typeof(List<ProjectModel>))]
        public IActionResult GetByFilter([FromQuery] ProjectFilter filter)
        {
            var projects = _projectService.Get(filter);
            var result = projects
                .Select(x => _mapper.Map<ProjectModel>(x))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(ProjectModel))]
        [ProducesResponseType(404)]
        public IActionResult GetById(Guid id)
        {
            var project = _projectService.FindById(id);

            if (project == null) return NotFound();

            return Ok(_mapper.Map<ProjectModel>(project));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CreateProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _mapper.Map<CreateProjectModel, Project>(model);
            _projectService.Create(project);
            var result = _mapper.Map<ProjectModel>(project);

            return CreatedAtAction(nameof(GetById), new { result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(Guid id, [FromBody] UpdateProjectModel model)
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
