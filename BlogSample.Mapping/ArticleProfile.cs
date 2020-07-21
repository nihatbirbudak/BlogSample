using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;

namespace BlogSample.Mapping
{
    public class ArticleProfile : ProfileBase
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
    }
}
