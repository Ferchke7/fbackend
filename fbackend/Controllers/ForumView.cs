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
        public string GetCurrentUserInfo()
        {
            return HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        }

    }
}