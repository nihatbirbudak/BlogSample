using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Model
{
    public class UserDetail : Entity<int>
    {
        public int UserDetailId { get; set; }

        public string Adress { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Sex { get; set; }
        public string Vocation { get; set; }
    }
}
