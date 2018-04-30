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
        [ProducesResponseType(200, Type = typeof(List<ProjectTaskModel>))]
        public IActionResult GetByFilter([FromQuery] ProjectTaskFilter filter)
        {
            var projectTasks = _projectTaskService.Get(filter);
            var result = projectTasks
                .Select(x => _mapper.Map<ProjectTaskModel>(x))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(ProjectTaskModel))]
        [ProducesResponseType(404)]
        public IActionResult GetById(Guid id)
        {
            var projectTask = _projectTaskService.FindById(id);

            if (projectTask == null) return NotFound();

            return Ok(_mapper.Map<ProjectTaskModel>(projectTask));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CreateProjectTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTask = _mapper.Map<CreateProjectTaskModel, ProjectTask>(model);
            _projectTaskService.Create(projectTask);
            var result = _mapper.Map<ProjectTaskModel>(projectTask);

            return CreatedAtAction(nameof(GetById), new { result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
