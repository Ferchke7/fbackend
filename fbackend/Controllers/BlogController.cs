using fbackend.Data;
using fbackend.DTO;
using fbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace fbackend.Controllers
{
    [Route("[controller]/[action]")]
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

        [HttpGet]
        [ActionName("getallpostwithcomments")]
        public async Task<List<Blog>> GetAllPostWithComments()
        {
            
            return await context.Blogs.OrderByDescending(b => b.CreateDate).Include(blog => blog.PostsComments).ToListAsync();
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

        [HttpGet]
        [ActionName("GetPostByID")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = context.Blogs.Find(postId);
            if (post is null) { 
            return BadRequest();
            }
            return Ok(post);
        }

        [HttpGet]
        [ActionName("GetPostComments")]
        public async Task<IActionResult> GetCommentsForBlog(int blogId)
        {
            var blog = await context.Blogs
                .Include(b => b.PostsComments)  // Eager load PostComments
                .FirstOrDefaultAsync(b => b.Id == blogId);

            if (blog == null)
            {
                return NotFound("Blog not found");
            }

            var comments = blog.PostsComments.ToList();

            return Ok(comments);
        }

        //fix it
        [HttpPost("{blogId}/comments")]
        public async Task<IActionResult> AddCommentToBlog(int blogId, [FromBody] PostComment_DTO postComment_DTO)
        {
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == getEmail);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var blog = await context.Blogs.Include(b => b.PostsComments).FirstOrDefaultAsync(b => b.Id == blogId);
            if (blog == null)
            {
                return NotFound("Blog not found");
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

            blog.PostsComments.Add(commentObject);

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
