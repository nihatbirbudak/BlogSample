using BlogSample.Core.Services;
using BlogSample.DTO;
using System.Collections.Generic;

namespace BlogSample.BLL.Abstract
{
    public interface ITagService : IServiceBase
    {
        List<TagDTO> getAll();
        TagDTO getTag(int Id);
        List<TagDTO> getTagNameList(string tagName);
        TagDTO newTag(TagDTO tag);
        TagDTO updateTag(TagDTO tag);
        bool deleteTag(int tagId);
    }
}
