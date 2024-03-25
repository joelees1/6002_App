﻿using Microsoft.Extensions.Logging;
using JL_CW_App.Interfaces;
using JL_CW_App.Services;
using JL_CW_App.ViewModels;
using JL_CW_App.Views;

namespace JL_CW_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiMicroMvvm<AppShell>(
				"Resources/Styles/Colors.xaml",
				"Resources/Styles/Styles.xaml")
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services
			.MapView<LoginPage, LoginPageViewModel>()
			.MapView<RegisterPage, RegisterPageViewModel>()
			.MapView<ArticlesPage, ArticleViewModel>() // home/articles page
			.MapView<SingleArticlePage, SingleArticleViewModel>() // single article page
			.MapView<BudgetPage, BudgetPageViewModel>() // shows a users budget and expense info
			.MapView<AccountPage, AccountPageViewModel>()
			.MapView<AppShell, AppShellViewModel>()

			.MapView<BmiPage, BmiPageViewModel>()
			.MapView<ClassicMauiPage, ClassicMauiPageViewModel>()
			.MapView<QuoteGeneratorPage, QuoteGeneratorPageViewModel>()
			.MapView<SavedQuotes, SavedQuotesViewModel>();

		builder.Services.AddSingleton<BaseViewModel>();
		builder.Services.AddSingleton<IAppState, AppState>();
		builder.Services.AddSingleton<IArticleService, NewsApiService>();
		builder.Services.AddSingleton<BaseViewModelMoreSimple>();
		builder.Services.AddSingleton<IQuoteService, QuoteRealService>();
		builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

		return builder.Build();
	}
}