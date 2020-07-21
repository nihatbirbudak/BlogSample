using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogSample.Model
{
    public class Comment : Entity<int>
    {
        public Comment()
        {
            Comments = new HashSet<Comment>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Read { get; set; }

        [ForeignKey("Article")]
        public Nullable<int> ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
