using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public Nullable<int> ArticleId { get; set; }

        public List<CommentDTO> Comments { get; set; }
        public ArticleDTO Article { get; set; }
    }
}
