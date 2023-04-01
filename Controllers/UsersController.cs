using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.DTOs;
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
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = await _userRepository.GetUsersAsync();
            // return Ok(users);
            var users = await _userRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{username}")]

        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
        //    var user =  await _userRepository.GetUserByUsernameAsync(username);
        //    return _mapper.Map<MemberDto>(user);

            return await _userRepository.GetMemberAsync(username);
        }
    }
}