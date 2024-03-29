using Newtonsoft.Json;

namespace JL_CW_App.Models;

// This class is used to store the data of the news articles that are fetched from the API
// The properties are decorated with the JsonProperty attribute to map the properties to the JSON keys
public class NewsArticle
{
    [JsonProperty("article_id")]
    public string Article_id { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("pubDate")]
    public string PubDate { get; set; }
    
    [JsonProperty("source_id")]
    public string Source_id { get; set; }
    
    [JsonProperty("link")]
    public string Link { get; set; }

    public NewsArticle() // Constructor to initialize the properties
    {
        Article_id = string.Empty;
        Title = string.Empty;
        Description = string.Empty;
        PubDate = string.Empty;
        Source_id = string.Empty;
        Link = string.Empty;
    }
}