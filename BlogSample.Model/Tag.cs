using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogSample.Model
{
    public class Tag : Entity<int>
    {
        public string Name { get; set; }

        [ForeignKey("Article")]
        public Nullable<int> ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
