using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Model
{
   public class Role : Entity<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
