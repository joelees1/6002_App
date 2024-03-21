using JL_CW_App.Views;

namespace JL_CW_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SingleArticlePage), typeof(SingleArticlePage));
		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

	}
}

