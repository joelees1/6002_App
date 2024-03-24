using JL_CW_App.Models;
namespace JL_CW_App.Interfaces;

public interface IArticleService
{
    public Task<List<NewsArticle>> GetArticles();
}