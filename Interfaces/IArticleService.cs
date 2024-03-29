using JL_CW_App.Models;
namespace JL_CW_App.Interfaces;

// Interface for ArticleService, which is used to get articles from the API
public interface IArticleService
{
    public Task<List<NewsArticle>> GetArticles(int category);
}