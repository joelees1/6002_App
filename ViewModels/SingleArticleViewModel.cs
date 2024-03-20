using JL_CW_App.Models;
using MauiMicroMvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JL_CW_App.ViewModels;

[QueryProperty(nameof(Article), "Article")]

public partial class SingleArticleViewModel : ObservableObject
{
    [ObservableProperty]
    NewsArticle _article;
}