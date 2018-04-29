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
    public class ProjectTasksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTasksController(
            IMapper mapper,
            IProjectTaskService projectTaskService
        )
        {
            _mapper = mapper;
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        public IActionResult GetByFilter([FromQuery] ProjectTaskFilter filter)
        {
            return Ok(_projectTaskService.Get(filter));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var project = _projectTaskService.FindById(id);

            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTask = _mapper.Map<CreateProjectTaskModel, ProjectTask>(model);
            _projectTaskService.Create(projectTask);

            return CreatedAtAction(nameof(GetById), new { projectTask.Id }, projectTask);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateProjectTaskModel model)
        {
            var projectTask = _projectTaskService.FindById(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(model, projectTask);
            _projectTaskService.Update(projectTask);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var projectTask = _projectTaskService.FindById(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            _projectTaskService.Remove(projectTask);

            return NoContent();
        }
    }
}
