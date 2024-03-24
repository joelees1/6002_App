using System.Windows.Input;
using JL_CW_App.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JL_CW_App.ViewModels;

[QueryProperty(nameof(Article), "Article")]

public partial class SingleArticleViewModel : ObservableObject
{
    public ICommand OpenArticleCommand { get; }

    [ObservableProperty]
    private NewsArticle? _article;
    
    public SingleArticleViewModel() 
    {
        OpenArticleCommand = new Command(async () => await OpenArticleInBrowser()); 
    }
    
    private async Task OpenArticleInBrowser()
    {
        try
        {
            if (Article?.Link != null)
            {
                await Browser.OpenAsync(Article.Link);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await Shell.Current.DisplayAlert("Error", "Could not open the article in the browser", "OK");
        }
    }
}