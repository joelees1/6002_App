using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using Client = Supabase.Client;

namespace JL_CW_App.ViewModels;

public class AccountPageViewModel : BaseViewModel
{
    private readonly Client _supabaseClient;
    private readonly IAppState _appState;

    public ICommand ChangePasswordCommand { get; set; }

    public string OldPassword
    {
        get => Get<string>();
        set
        {
            Set(value);
            (ChangePasswordCommand as Command)?.ChangeCanExecute();
        }
    }
    public string NewPassword
    {
        get => Get<string>();
        set
        {
            Set(value);
            (ChangePasswordCommand as Command)?.ChangeCanExecute();
        }
    }

    public AccountPageViewModel(ViewModelContext context, IAppState appState): base(context)
    {
        _supabaseClient = new Client(Constants.Url, Constants.SupabaseKey);
        _appState = appState;
        ChangePasswordCommand = new Command(async () => await ChangePassword(),
            () => !string.IsNullOrEmpty(OldPassword) && !string.IsNullOrEmpty(NewPassword));
    }
    
    public User CurrentUser => _appState.CurrentUser; // get the user from the app state

    /*public override void OnAppearing()
    {
        base.OnAppearing();
        OldPassword = string.Empty;
        NewPassword = string.Empty;
    }*/

    private async Task ChangePassword()
    {
        /*try
        {
            // Change the user's password
            var response = await _supabaseClient.Auth.Update(new User()
            {
                Email = _appState.CurrentUser.Email,
                Password = OldPassword
            }, NewPassword);
            
            if (response.Error != null)
            {
                throw new Exception(response.Error.Message);
            }
            await Shell.Current.DisplayAlert("Success", "Password changed successfully", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }*/
    }
}