using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Views;

namespace JL_CW_App.ViewModels;

public class AppShellViewModel : BaseViewModel
{
    private readonly IAppState _state;
    public ICommand LogOutCommand { get; set; }
    public ICommand AccountPageCommand { get; set; }
    
    public AppShellViewModel(ViewModelContext context, IAppState state) : base(context)
    {
        _state = state;
        LogOutCommand = new Command(ExecuteLogout);
        AccountPageCommand = new Command(NavigateToAccountPage);
    }

    private void ExecuteLogout()
    {
        _state.CurrentUser = null;
        Shell.Current.GoToAsync("//login");
    }
    
    private void NavigateToAccountPage()
    {
        Shell.Current.GoToAsync("//AccountPage");
    }
}