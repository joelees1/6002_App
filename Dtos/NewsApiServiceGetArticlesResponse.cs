namespace JL_CW_App.Dtos;
using JL_CW_App.Models;

public class NewsApiServiceGetArticlesResponse
{
    public string Status { get; set; }
    public int totalResults { get; set; }
    public List<NewsArticle> Results { get; set; }
}