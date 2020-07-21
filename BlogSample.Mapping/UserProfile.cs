using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;


namespace BlogSample.Mapping
{
    public class UserProfile : ProfileBase
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
