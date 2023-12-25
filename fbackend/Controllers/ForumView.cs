using fbackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Diagnostics;

namespace fbackend.Controllers
{
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ForumView : ControllerBase
    {
        private static List<NewsItem> _newsItems = new List<NewsItem>()
        {
            new NewsItem(1, "John Doe", "First news item content"),
            new NewsItem(2, "Jane Smith", "Second news item content with more details"),
            new NewsItem(3, "Bob Johnson", "Third news item with exciting information")
        };

        [HttpGet]
        public async Task<IEnumerable<NewsItem>> GetNewsAsync()
        {
            //var token = await HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            
            Debug.WriteLine(getEmail);
            return _newsItems;
        }

        [HttpGet("{id}")]
        public NewsItem GetNewsById(int id)
        {
            return _newsItems.Find(item => item.Id == id);
        }

        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == "email");
            // Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                // Access user information from claims
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub");
                
                if (userIdClaim != null && userEmailClaim != null)
                {
                    // Extract user information
                    var userId = userIdClaim.Value;
                    var userEmail = userEmailClaim.Value;

                    // Use the user information as needed
                    return Ok(new { UserId = userId, UserEmail = userEmail });
                }
            }

            // Return an error or appropriate response if the user is not authenticated
            return Unauthorized();
        }

        [HttpGet("get-user-email")]
        public async Task<IActionResult> GetUserEmailAsync()
        {
            var token = await HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
            Debug.WriteLine(token);
            var userEmail = User.FindFirst("email")?.Value;
            if (string.IsNullOrEmpty(userEmail))
            {
                // Handle the case where the email claim is not found
                return BadRequest("User email not found in claims.");
            }

            // Your logic when the email claim is found
            return Ok(new { Email = userEmail });
        }
    }
}