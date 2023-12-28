using fbackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace fbackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersInfo : ControllerBase
    {
        ApplicationDbContext _context;

        public UsersInfo(ApplicationDbContext _context) { 
            this._context = _context;
        }

        [HttpGet("currentUser")]
        public async Task<ActionResult> GetUser() {

            var userEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);    

            return Ok(user);
        }

        [HttpGet("allusers")]
        public async Task<ActionResult> GetAllUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost("changename")]
        public async Task<ActionResult> ChangeNickName(String newName)
        {
            var userEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            var usersWithSameName = await _context.Users.FirstOrDefaultAsync(u => u.Name == newName);

            if (usersWithSameName != null)
            {
                ModelState.AddModelError("newName", "Nickname already exist, please choose another nickname");
                return BadRequest(ModelState);
            }

            user.Name = newName;

            await _context.SaveChangesAsync();
            return Ok(user);

        }
    }
}
