using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using JL_CW_App.Views;

namespace JL_CW_App.ViewModels;

public class ArticleViewModel : BaseViewModel
{
    private readonly IArticleService _articleService;
    public ObservableCollection<NewsArticle> Articles { get; set; } = new();
    public ICommand NavigateToSingleArticlePageCommand { get; }

    public ArticleViewModel(ViewModelContext context, IArticleService articleService) : base(context)
    {
        _articleService = articleService;
        InitializeArticles();
        NavigateToSingleArticlePageCommand = new Command<NewsArticle>(async (article) => await NavigateToSingleArticlePage(article));
    }
    
    private async Task InitializeArticles()
    {
        var articles = await _articleService.GetArticles();
        foreach (var article in articles)
        {
            Articles.Add(article);
        }
    }
    
    private async Task NavigateToSingleArticlePage(NewsArticle article)
    {
        // Navigate to the SingleArticlePage and pass the selected article as a parameter
        await Shell.Current.GoToAsync(nameof(SingleArticlePage), new Dictionary<string, object>()
        {
            { "Article", article}
        });
    }
}
