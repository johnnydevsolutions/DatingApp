using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using back.Interfaces;
using DatingProject.Data;
using DatingProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatingBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize]
    public class UsersController : BaseApiController
    {
     
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("{username}")]

        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
             return await _userRepository.GetUserByUsernameAsync(username);
        }
    }
}