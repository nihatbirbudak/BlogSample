
using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSample.Model
{
    public class User : Entity<int>
    {
        public User()
        {
            Articles = new HashSet<Article>();
        }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }

        [ForeignKey("Role")]
        public Nullable<int> RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
