using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface IArticleService : IServiceBase
    {
        List<ArticleDTO> getAll();
        ArticleDTO getArticle(int articleId);
        List<ArticleDTO> getArticleName(string articleName);
        ArticleDTO newArticle(ArticleDTO article);
        ArticleDTO updateArticle(ArticleDTO article);
        bool deleteArticle(int articleId);
    }
}
