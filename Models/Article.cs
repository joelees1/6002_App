using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace JL_CW_App.Models;

public class NewsArticle
{
    [JsonProperty("article_id")] // Map property to the JSON field
    public string Article_id { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("pubDate")]
    public string PubDate { get; set; }
    
    //[JsonConverter(typeof(DateTimeConverter))]
    //public DateTime PubDate { get; set; }
    
    [JsonProperty("source_id")]
    public string Source_id { get; set; }
    
    [JsonProperty("link")]
    public string Link { get; set; }

    public NewsArticle()
    {
        Article_id = string.Empty;
        Title = string.Empty;
        Description = string.Empty;
        //PubDate = DateTime.MinValue;
        PubDate = string.Empty;
        Source_id = string.Empty;
        Link = string.Empty;
    }
}