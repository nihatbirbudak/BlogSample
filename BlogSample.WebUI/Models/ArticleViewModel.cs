using BlogSample.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlogSample.WebUI.Models
{
    public class ArticleViewModel
    {
        public ArticleDTO ArticleDTO { get; set; }
        public List<ArticleDTO> ArticleDTOs { get; set; }

        public List<CategoryDTO> CategoryDTOs { get; set; }
        public IFormFile File { get; set; }
        public CommentDTO CommentDTO { get; set; }
    }
}
