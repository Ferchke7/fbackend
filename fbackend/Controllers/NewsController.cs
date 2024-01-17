using AutoMapper;
using fbackend.Data;
using fbackend.DTO;
using fbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        ApplicationDbContext _context;
        private IMapper _mapper;
        public NewsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<NewsArticle> GetAllArticles()
        {
            var articles = _context.NewsArticles.ToList();
            return articles;
        }

        [HttpPost]
        public async void PostArticle(NewsArticleDTO article) {
            var articleInfo = _mapper.Map<NewsArticle>(article);
            _context.NewsArticles.Add(articleInfo);
            _context.SaveChanges();
            
        }
    }
}
