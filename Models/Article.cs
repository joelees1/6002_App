namespace JL_CW_App.Models;

public class NewsArticle
{
    // Using appropriate names for clarity
    //[JsonProperty("article_id")] // Assuming you'll use JSON serialization
    public string ArticleId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedAt { get; set; }
    public string SourceId { get; set; }
    public string Url { get; set; }

    public NewsArticle()
    {
        ArticleId = string.Empty;
        Title = string.Empty;
        Description = string.Empty;
        PublishedAt = DateTime.MinValue;
        SourceId = string.Empty;
        Url = string.Empty;
    }

    public NewsArticle(string articleId, string title, string description, DateTime publishedAt, string sourceId, string url)
    {
        ArticleId = articleId;
        Title = title;
        Description = description;
        PublishedAt = publishedAt;
        SourceId = sourceId;
        Url = url;
    }
}