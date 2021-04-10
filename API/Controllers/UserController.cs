using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrapp.Core.Entities;
using hrapp.Core.Interface;
using hrapp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;

namespace hrapp.API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result == null)
            return NotFound();

            return Ok(result);
        }

        [HttpGet("getUserByName/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            var result = await _userService.GetUserByNameAsync(name);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(user);
                return CreatedAtAction("GetUserByName", new { name =  user.LastName }, user);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = id;
                await _userService.UpdateUser(user);
                return Ok();
            }

            return BadRequest(ModelState);
        }

    }
}