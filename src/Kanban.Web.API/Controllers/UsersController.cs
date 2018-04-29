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
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(
            IMapper mapper,
            IUserService userService
        )
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetByFilter([FromQuery] UserFilter filter)
        {
            return Ok(_userService.Get(filter));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.FindById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<CreateUserModel, User>(model);
            _userService.Create(user);

            return CreatedAtAction(nameof(GetById), new { user.Id }, user);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateUserModel model)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(model, user);
            _userService.Update(user);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user);

            return NoContent();
        }
    }
}
