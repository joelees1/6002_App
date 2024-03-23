using System.Collections.ObjectModel;
using System.Text.Json;
using System.Web;
using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using JL_CW_App.Services;
using JL_CW_App.Views;
using ShellNavigationQueryParameters = Microsoft.Maui.Controls.ShellNavigationQueryParameters;
using static JL_CW_App.AppState;

namespace JL_CW_App.ViewModels;

public class ArticleViewModel : BaseViewModel
{
    private readonly IArticleService _articleService;
    //private readonly IAppState _appState;
    public ObservableCollection<NewsArticle> Articles { get; set; } = new();
    public ICommand NavigateToSingleArticlePageCommand { get; set; }

    public ArticleViewModel(ViewModelContext context, IArticleService articleService, IAppState appState ) : base(context)
    {
        _articleService = articleService;
        //_appState = appState;
        InitializeArticles();
        NavigateToSingleArticlePageCommand = new Command<NewsArticle>(async (article) => await NavigateToSingleArticlePage(article));
    }
    
    // get the user from the app state
    //public User CurrentUser => _appState.CurrentUser;
    
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
