using fbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbackend.Controllers
{
    [Route("api/[controller]")]
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
        public IEnumerable<NewsItem> GetNews()
        {
            return _newsItems;
        }

        [HttpGet("{id}")]
        public NewsItem GetNewsById(int id)
        {
            return _newsItems.Find(item => item.Id == id);
        }
    }
}
