using JL_CW_App.Models;
using JL_CW_App.ViewModels;

namespace JL_CW_App.Views;

public partial class ArticlesPage
{
    public ArticlesPage()
    {
        InitializeComponent();
    }

    private void ListView_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        var article = e.Item as NewsArticle; 
        (BindingContext as ArticleViewModel)?.NavigateToSingleArticlePageCommand.Execute(article);
    }
}