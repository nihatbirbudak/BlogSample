using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class UserDetailDTO
    {
        public string Adress { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Sex { get; set; }
        public string Vocation { get; set; }
    }
}
