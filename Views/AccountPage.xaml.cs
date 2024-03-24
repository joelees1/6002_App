namespace JL_CW_App.Views;

public partial class AccountPage
{
    public AccountPage()
    {
        InitializeComponent();
    }
    
    void OldPassword_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.AccountPageViewModel);
        viewModel.OldPassword = e.NewTextValue;
    }

    void NewPassword_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.AccountPageViewModel);
        viewModel.NewPassword = e.NewTextValue;
    }
}