using AutoMapper;
using fbackend.DTO;
using fbackend.Models;

namespace fbackend.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() {
            CreateMap<NewsArticleDTO, NewsArticle>();

        }
    }
}
