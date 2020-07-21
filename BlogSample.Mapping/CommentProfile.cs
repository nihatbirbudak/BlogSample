using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;

namespace BlogSample.Mapping
{
    public class CommentProfile : ProfileBase
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
