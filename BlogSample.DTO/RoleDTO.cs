using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserDTO> Users { get; set; }

    }
}
