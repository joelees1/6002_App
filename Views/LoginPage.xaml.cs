namespace JL_CW_App.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(ViewModels.LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    void Username_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
        viewModel.Username = e.NewTextValue;
    }

    void Password_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
        viewModel.Password = e.NewTextValue;
    }
}
