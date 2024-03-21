using System.Windows.Input;
using JL_CW_App.Models;
using MauiMicroMvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JL_CW_App.ViewModels;

[QueryProperty(nameof(Article), "Article")]

public partial class SingleArticleViewModel : ObservableObject
{
    public ICommand OpenArticleCommand { get; }

    [ObservableProperty]
    NewsArticle _article;
    
    public SingleArticleViewModel() 
    {
        OpenArticleCommand = new Command(async () => await OpenArticleInBrowser()); 
    }
    
    async Task OpenArticleInBrowser()
    {
        if (Article?.Url != null)
        {
            await Browser.OpenAsync(Article.Url);
        }
    }
}