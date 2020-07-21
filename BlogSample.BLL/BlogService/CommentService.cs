using BlogSample.BLL.Abstract;
using BlogSample.Core.Data.UnitOfWork;
using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSample.BLL.BlogService
{
    public class CommentService : ICommentService
    {
        private readonly IUnitofWork uow;
        public CommentService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteComment(int commentId)
        {
            try
            {
                var delete = uow.GetRepository<Comment>().Get(z => z.Id == commentId);
                uow.GetRepository<Comment>().Delete(delete);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public List<CommentDTO> getAll()
        {
            var list = uow.GetRepository<Comment>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CommentDTO>>(list);
        }

        public List<CommentDTO> getByArticleId(int Id)
        {
            var CommentList = uow.GetRepository<Comment>().GetAll().Where(z => z.ArticleId == Id && z.Read == true).ToList();
            return MapperFactory.CurrentMapper.Map<List<CommentDTO>>(CommentList);
        }

        public CommentDTO getComment(int Id)
        {
            var comment = uow.GetRepository<Comment>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CommentDTO>(comment);
        }

        public bool markasRead(int commentId)
        {
            try
            {
                var update = uow.GetRepository<Comment>().Get(z => z.Id == commentId);
                update.Read = true;
                uow.GetRepository<Comment>().Update(update);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CommentDTO newComment(CommentDTO comment)
        {
            if (!uow.GetRepository<Comment>().GetAll().Any(z => z.Title == comment.Title))
            {
                var added = MapperFactory.CurrentMapper.Map<Comment>(comment);
                uow.GetRepository<Comment>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CommentDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public CommentDTO updateComment(CommentDTO comment)
        {
            var update = uow.GetRepository<Comment>().Get(z => z.Id == comment.Id);
            update = MapperFactory.CurrentMapper.Map<Comment>(comment);
            uow.GetRepository<Comment>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CommentDTO>(update);
        }
    }
}
