using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services;

namespace TestApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, UsersData users)
        {
            _userService = userService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(UserModel user)
        {
            var result = await _userService.Auth(user);

            if (result == null)
            {
                return BadRequest("Auth failed");
            }

            return Ok(result);
        }

        [HttpPost("reg")]
        public async Task<IActionResult> Register(UserModel user)
        {
            var result = await _userService.Register(user);

            if (result == null)
            {
                return BadRequest("Register failed");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserModel user)
        {
            var result = await _userService.Update(user);

            if (result == null)
            {
                return BadRequest("Edit failed");
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserModel user)
        {
            var result = await _userService.Delete(user);

            if (result == null)
            {
                return BadRequest("Delete failed");
            }

            return Ok(result);
        }
    }
}
