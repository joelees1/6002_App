namespace JL_CW_App.Models;

public class NewsArticle
{
    public string Title { get; set;} 
    public string Description { get; set;} 
    public DateTime DatePublished { get; set;} 
    public string Url { get; set;}
    
    public NewsArticle()
    {
    }

    public NewsArticle(string title, string description, DateTime datePublished, string url)
    {
        Title = title;
        Description = description;
        DatePublished = datePublished;
        Url = url;
    }
}