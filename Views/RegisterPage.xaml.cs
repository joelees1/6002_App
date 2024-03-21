namespace JL_CW_App.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
    
    private void Email_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.RegisterPageViewModel);
        viewModel.Email = e.NewTextValue;
    }

    private void Password_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.RegisterPageViewModel);
        viewModel.Password = e.NewTextValue;
    }
}