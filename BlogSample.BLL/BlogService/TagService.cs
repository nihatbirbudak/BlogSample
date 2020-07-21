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
    public class TagService : ITagService
    {
        private readonly IUnitofWork uow;
        public TagService(IUnitofWork _uow)
        {
            uow = _uow;
        }

        public bool deleteTag(int tagId)
        {
            try
            {
                var delete = uow.GetRepository<Tag>().Get(z => z.Id == tagId);
                uow.GetRepository<Tag>().Delete(delete);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public List<TagDTO> getAll()
        {
            var list = uow.GetRepository<Tag>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<TagDTO>>(list);
        }

        public TagDTO getTag(int Id)
        {
            var tag = uow.GetRepository<Tag>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<TagDTO>(tag);
        }

        public List<TagDTO> getTagNameList(string tagName)
        {
            var getName = uow.GetRepository<Tag>().Get(z => z.Name.Contains(tagName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<TagDTO>>(getName);
        }

        public TagDTO newTag(TagDTO tag)
        {
            if (!uow.GetRepository<Tag>().GetAll().Any(z => z.Name == tag.Name))
            {
                var added = MapperFactory.CurrentMapper.Map<Tag>(tag);
                uow.GetRepository<Tag>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<TagDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public TagDTO updateTag(TagDTO tag)
        {
            var update = uow.GetRepository<Tag>().Get(z => z.Id == tag.Id);
            update = MapperFactory.CurrentMapper.Map<Tag>(tag);
            uow.GetRepository<Tag>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<TagDTO>(update);
        }
    }
}
