using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface ICommentService : IServiceBase
    {
        List<CommentDTO> getAll();
        CommentDTO getComment(int Id);
        List<CommentDTO> getByArticleId(int Id);
        CommentDTO newComment(CommentDTO Comment);
        CommentDTO updateComment(CommentDTO Comment);
        bool deleteComment(int commentId);
        bool markasRead(int commentId);
    }
}
