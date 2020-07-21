using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;


namespace BlogSample.Mapping
{
    public class RoleProfile : ProfileBase
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }

    }
}
