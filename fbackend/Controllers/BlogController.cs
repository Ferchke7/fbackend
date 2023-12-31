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
                Author = user.Name,
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
            return await context.Blogs.OrderByDescending(b => b.CreateDate).ToListAsync();
        }

        [HttpDelete("deletePost")]
        public async Task<IActionResult> DeleteMyPost(int postId)
        {
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;

            var post = context.Blogs.Find(postId);
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == getEmail);
            if (post is null && post.UserId != user.Id) {
                return BadRequest();
            }

            context.Blogs.Remove(post);
            await context.SaveChangesAsync();
            return Ok();
        }


        //fix it
        [HttpPost("postcomment")]
        public async Task<IActionResult> AddCommentIntoBlog(PostComment_DTO postComment_DTO)
        {
            try
            {
                var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;

                // Find the user
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == getEmail);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                // Find the post
                var post = await context.Blogs.Include(b => b.PostsComments).FirstOrDefaultAsync(b => b.Id == postComment_DTO.PostId);
                if (post == null)
                {
                    return BadRequest("Post not found");
                }

                var commentObject = new PostComments
                {
                    Username = user.Name,
                    UserId = user.Id,
                    Comment = postComment_DTO.Comment,
                    likes = 0,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                post.PostsComments.Add(commentObject);

                // You may want to consider wrapping this in a try-catch block
                // to handle potential exceptions during save changes.
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


    }
}
