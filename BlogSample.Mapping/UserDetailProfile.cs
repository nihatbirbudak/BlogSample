using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;

namespace BlogSample.Mapping
{
    public class UserDetailProfile : ProfileBase
    {
        public UserDetailProfile()
        {
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
        }
    }
}
