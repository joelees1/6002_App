using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;

namespace JL_CW_App.ViewModels;

public class AppShellViewModel : BaseViewModel
{
    private readonly IAppState _state;
    public ICommand LogOutCommand { get; set; }
    
    public AppShellViewModel(ViewModelContext context, IAppState state) : base(context)
    {
        _state = state;
        LogOutCommand = new Command(ExecuteLogout);
    }

    // This method is called when the user clicks the logout button
    // It sets the current user to null and navigates to the login page
    private void ExecuteLogout()
    {
        _state.CurrentUser = null;
        Shell.Current.GoToAsync("//login");
    }
}