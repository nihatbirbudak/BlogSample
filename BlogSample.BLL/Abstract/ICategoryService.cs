using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface ICategoryService : IServiceBase
    {
        List<CategoryDTO> getAll();
        CategoryDTO getCategory(int categoryId);
        List<CategoryDTO> getCategoryNameList(string categoryName);
        CategoryDTO newCategory(CategoryDTO category);
        CategoryDTO updateCategory(CategoryDTO category);
        bool deleteCategory(int categoryId);
    }
}
