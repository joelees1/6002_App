using System.Collections.ObjectModel;
using System.Text.Json;
using System.Web;
using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using JL_CW_App.Views;
using ShellNavigationQueryParameters = Microsoft.Maui.Controls.ShellNavigationQueryParameters;

namespace JL_CW_App.ViewModels;

public class ArticleViewModel : BaseViewModel
{
    public ObservableCollection<NewsArticle> Articles { get; set; } = new();
    public ICommand NavigateToSingleArticlePageCommand { get; set; }

    public ArticleViewModel(ViewModelContext context) : base(context)
    {
        InitializeArticles();
        NavigateToSingleArticlePageCommand = new Command<NewsArticle>(async (article) => await NavigateToSingleArticlePage(article));
    }
    
    private async Task NavigateToSingleArticlePage(NewsArticle article)
    {
        // Navigate to the SingleArticlePage and pass the selected article as a parameter
        await Shell.Current.GoToAsync(nameof(SingleArticlePage), new Dictionary<string, object>()
        {
            { "Article", article}
        });
    }
    
    private void InitializeArticles()
    {
        Articles.Add(new NewsArticle
        {
            ArticleId = "bdkbvw", 
            Title = "Exciting Financial News", 
            Description = "Learn about the latest market trends...", 
            PublishedAt = DateTime.Now, 
            SourceId = "Times",
            Url = "https://fake-news-site.com/1"
        });
        Articles.Add(new NewsArticle
        {
            ArticleId = "skjs292",
            Title = "Budgeting Tips for Beginners",
            Description = "Discover how to save effectively.",
            PublishedAt = DateTime.Now.AddDays(-3), 
            SourceId = "Forbes",
            Url = "https://fake-news-site.com/2"
        });
        Articles.Add(new NewsArticle
        {
            ArticleId = "12lnl22",
            Title = "Market Analysis: Tech Stocks Surge",
            Description = "Get insights on the tech sector's performance.",
            PublishedAt = DateTime.Now.AddDays(-1), 
            SourceId = "Bloomberg",
            Url = "https://fake-news-site.com/3"
        });
        Articles.Add(new NewsArticle
        {
            ArticleId = "bdkbvw", 
            Title = "Exciting Financial News", 
            Description = "Learn about the latest market trends...", 
            PublishedAt = DateTime.Now, 
            SourceId = "Times",
            Url = "https://fake-news-site.com/1"
        });
        Articles.Add(new NewsArticle
        {
            ArticleId = "skjs292",
            Title = "Budgeting Tips for Beginners",
            Description = "Discover how to save effectively.",
            PublishedAt = DateTime.Now.AddDays(-3), 
            SourceId = "Forbes",
            Url = "https://fake-news-site.com/2"
        });
        Articles.Add(new NewsArticle
        {
            ArticleId = "12lnl22",
            Title = "Market Analysis: Tech Stocks Surge",
            Description = "Get insights on the tech sector's performance.",
            PublishedAt = DateTime.Now.AddDays(-1), 
            SourceId = "Bloomberg",
            Url = "https://fake-news-site.com/3"
        });
    }
}
