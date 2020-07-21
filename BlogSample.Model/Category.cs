using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Model
{
    public class Category : Entity<int>
    {

        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
