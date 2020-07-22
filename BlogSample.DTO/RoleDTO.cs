using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogSample.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Display(Name ="Kullanıcı Rolü")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserDTO> Users { get; set; }

    }
}
