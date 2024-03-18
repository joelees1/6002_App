using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;

namespace JL_CW_App.ViewModels;

public class ArticleViewModel : BaseViewModel
{
    public ObservableCollection<NewsArticle> Articles { get; set; } = new();

    public ArticleViewModel(ViewModelContext context) : base(context)
    {
        InitializeArticles();
    }
    
    private void InitializeArticles()
    {
        Articles.Add(new NewsArticle { Title = "Exciting Financial News", Description = "Learn about the latest market trends...", DatePublished = DateTime.Now, Url = "https://fake-news-site.com/1" });
        Articles.Add(new NewsArticle { Title = "Budgeting Tips for Beginners", Description = "Discover how to save effectively.", DatePublished = DateTime.Now.AddDays(-3), Url = "https://fake-news-site.com/2" });
        Articles.Add(new NewsArticle { Title = "Exciting Financial News", Description = "Learn about the latest market trends...", DatePublished = DateTime.Now, Url = "https://fake-news-site.com/1" });
        Articles.Add(new NewsArticle { Title = "Budgeting Tips for Beginners", Description = "Discover how to save effectively.", DatePublished = DateTime.Now.AddDays(-3), Url = "https://fake-news-site.com/2" });
        Articles.Add(new NewsArticle { Title = "Exciting Financial News", Description = "Learn about the latest market trends...", DatePublished = DateTime.Now, Url = "https://fake-news-site.com/1" });
        Articles.Add(new NewsArticle { Title = "Budgeting Tips for Beginners", Description = "Discover how to save effectively.", DatePublished = DateTime.Now.AddDays(-3), Url = "https://fake-news-site.com/2" });
    }
}
