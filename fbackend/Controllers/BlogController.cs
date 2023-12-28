using fbackend.Data;
using fbackend.DTO;
using fbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace fbackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        
        ApplicationDbContext context;

        public BlogController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost(Name = "createpost")]
        public async Task<ActionResult<Post_DTO>> CreatePostAsync(Post_DTO post_DTO)
        {
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == getEmail);
            var postCreate = new Blog
            {
                UserId = user.Id,
                TitleName = post_DTO.TitleName,
                Visiters = 0,
                Likes = 0,
                Description = post_DTO.Description,
            };

            var checkIfPosted = context.Blogs.Add(postCreate);
            await context.SaveChangesAsync();
            return Ok(post_DTO);
        }

        [HttpGet(Name = "getallpost")]
        public async Task<List<Blog>> GetAllPosts()
        {
            return await context.Blogs.ToListAsync();
        }
       
    }
}
