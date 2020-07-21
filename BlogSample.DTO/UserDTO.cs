using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public Nullable<int> RoleId { get; set; }

        public RoleDTO roleDTO { get; set; }
        public Nullable<int> UserDetailId { get; set; }
        public UserDetailDTO userDetailDTO { get; set; }
    }
}
