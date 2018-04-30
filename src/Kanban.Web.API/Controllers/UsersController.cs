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
        [ProducesResponseType(200, Type = typeof(List<UserModel>))]
        public IActionResult GetByFilter([FromQuery] UserFilter filter)
        {
            var users = _userService.Get(filter);
            var result = users
                .Select(x => _mapper.Map<UserModel>(x))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(UserModel))]
        [ProducesResponseType(404)]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.FindById(id);

            if (user == null) return NotFound();

            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<CreateUserModel, User>(model);
            _userService.Create(user);
            var result = _mapper.Map<UserModel>(user);

            return CreatedAtAction(nameof(GetById), new { result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
