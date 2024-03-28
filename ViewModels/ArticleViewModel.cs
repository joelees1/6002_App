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
    public ObservableCollection<NewsArticle> Articles { get; set; } = new ();
    public NewsArticle SelectedArticle { get; set; } // CollectionView.SelectedItem
    public ICommand StudentArticlesCommand { get; set; }
    public ICommand UkArticlesCommand { get; set; }
    public ICommand NavigateToSingleArticlePageCommand { get; }

    public ArticleViewModel(ViewModelContext context, IArticleService articleService) : base(context)
    {
        _articleService = articleService;
        StudentArticlesCommand = new Command(async () => await InitialiseArticles(1));
        UkArticlesCommand = new Command(async () => await InitialiseArticles(2));
        NavigateToSingleArticlePageCommand = new Command( () => NavigateToSingleArticlePage(SelectedArticle));
    }
    
    public override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await InitialiseArticles(1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async Task InitialiseArticles(int category)
    {
        Articles.Clear();
        var articles = await _articleService.GetArticles(category);
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
