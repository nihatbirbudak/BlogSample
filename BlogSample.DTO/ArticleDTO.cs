using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int NumberofReadings { get; set; }
        public int NumberofLikes { get; set; }
        public bool IsRelease { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public UserDTO UserDTO { get; set; }
        public CategoryDTO GetCategoryDTO { get; set; }
        public List<CommentDTO> CommentDTOs { get; set; }
        public List<TagDTO> tagDTOs { get; set; }
    }
}
