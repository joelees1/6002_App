using JL_CW_App.Converters;
using Newtonsoft.Json;

namespace JL_CW_App.Models;

public class NewsArticle
{
    public string Article_id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PubDate { get; set; }
    
    //[JsonConverter(typeof(DateTimeConverter))]
    //public DateTime PubDate { get; set; }
    public string Source_id { get; set; }
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