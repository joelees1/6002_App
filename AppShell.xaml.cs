using JL_CW_App.Views;

namespace JL_CW_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		// single article page
		Routing.RegisterRoute(nameof(SingleArticlePage), typeof(SingleArticlePage));
		
		// registration page
		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
	}
}
