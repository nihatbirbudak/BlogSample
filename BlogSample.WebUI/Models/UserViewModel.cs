using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSample.WebUI.Models
{
    public class UserViewModel
    {
        public List<UserDTO> UserDTOs { get; set; }
        public UserDTO UserDTO { get; set; }
        public List<RoleDTO> RoleDTOs { get; set; }
    }
}
