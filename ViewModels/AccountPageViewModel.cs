using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using Newtonsoft.Json;
using Supabase.Gotrue;
using Client = Supabase.Client;
using JL_CW_App.Models;

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
    
    public Models.User CurrentUser => _appState.CurrentUser; // get the user from the app state
    
    public override void OnAppearing() // Clear the password fields whenever the page appears
    {
        base.OnAppearing();
        OldPassword = string.Empty;
        NewPassword = string.Empty;
    }
    
    /* This function has to login the user to supabase again as it uses a new _supabaseclient using
     the given 'current/old password' if this succeeds, the password is then changed successfully */
    private async Task ChangePassword()
    {
        try
        {
            // Log the user in with the current password
            var session = await _supabaseClient.Auth.SignIn(_appState.CurrentUser.Email, OldPassword);
            
            // set and update the password
            var attrs = new UserAttributes { Password = NewPassword };
            var response = await _supabaseClient.Auth.Update(attrs);
            await Shell.Current.DisplayAlert("Success", "Password changed successfully", "OK");
            
            // logout the user
            _appState.CurrentUser = null;
            await Shell.Current.GoToAsync("//login");
        }
        // Handle invalid email or password error from Supabase
        catch (Supabase.Gotrue.Exceptions.GotrueException e)
        {
            Console.WriteLine(e);
            var errorData = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Message);

            if (errorData.ContainsKey("error") && errorData["error"] == "invalid_grant")
            {
                await Shell.Current.DisplayAlert("Error", "Incorrect current password.", "OK");
            } 
        }
        // Handle any other errors
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}