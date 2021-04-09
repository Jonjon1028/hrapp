using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrapp.Core.Entities;
using hrapp.Core.Interface;
using hrapp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hrapp.API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var users = await _repo.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _repo.GetUserByIdAsync(id);
            if (result == null)
            return NotFound();

            return Ok(result);
        }

        [HttpGet("getUserByName/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            var result = await _repo.GetUserByNameAsync(name);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateUser(user);
                return CreatedAtAction("GetUserByName", new { name =  user.LastName }, user);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateUser(user);
                return Ok();
            }

            return BadRequest(ModelState);
        }

    }
}