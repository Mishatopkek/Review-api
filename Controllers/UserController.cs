using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApi.Data;
using ReviewApi.Data.ApiModels;
using ReviewApi.Data.Models;

namespace ReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiUser>>> Get()
        {
            return await _context.Users.Select(x => UsersToApiUsers(x)).ToListAsync();
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public ApiUser Get(int id)
        {
            return UsersToApiUsers(_context.Users.FirstOrDefault(x => x.Id == id));
        }
        private static ApiUser UsersToApiUsers(User user) =>
            new ApiUser
            {
                Name = user.Name,
                Login = user.Login
            };
    }
}
