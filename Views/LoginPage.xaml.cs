namespace JL_CW_App.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    void Email_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
        viewModel.Email = e.NewTextValue;
    }

    void Password_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
        viewModel.Password = e.NewTextValue;
    }
}
