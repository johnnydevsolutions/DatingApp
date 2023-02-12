using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DatingProject.Data;
using DatingProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatingBack.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
       {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}