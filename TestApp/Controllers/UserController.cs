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

        [HttpGet]
        public ActionResult<UserModel> Get(UserModel user)
        {
            var result = _userService.Auth(user);

            if (result == null)
            {
                return BadRequest("Auth failed");
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<UserModel> Post(UserModel user)
        {
            var result = _userService.Register(user);

            if (result == null)
            {
                return BadRequest("Register failed");
            }
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<UserModel> Put(UserModel user)
        {
            var result = _userService.Edit(user);

            if (result == null)
            {
                return BadRequest("Edit failed");
            }

            return Ok(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        public ActionResult<UserModel> Delete(UserModel user)
        {
            var result = _userService.Delete(user);

            if (result == null)
            {
                return BadRequest("Edit failed");
            }

            return Ok(result);
        }
    }
}
