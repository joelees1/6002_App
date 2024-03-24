namespace JL_CW_App.Dtos;
using Models;

public class NewsApiServiceGetArticlesResponse
{
    public string Status { get; set; }
    public int TotalResults { get; set; }
    public List<NewsArticle> Results { get; set; }
}