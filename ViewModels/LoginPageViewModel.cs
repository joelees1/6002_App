using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Views;
using Newtonsoft.Json;
using Supabase;

namespace JL_CW_App.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
    private readonly Client _supabaseClient;
    private readonly IAppState _appState;

    public ICommand LoginCommand { get; set; }
    public ICommand NavigateToRegisterPageCommand { get; set; }

    public string Email
    {
        get => Get<string>();
        set
        {
            Set(value);
            (LoginCommand as Command)?.ChangeCanExecute();
        }
    }
    public string Password
    {
        get => Get<string>();
        set
        {
            Set(value);
            (LoginCommand as Command)?.ChangeCanExecute();
        }
    }

    public LoginPageViewModel(ViewModelContext context, IAppState appState): base(context)
    {
        _supabaseClient = new Client(Constants.Url, Constants.SupabaseKey);
        _appState = appState;
        LoginCommand = new Command(async () => await Login(),
            () => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password));
        NavigateToRegisterPageCommand = new Command(async () => await NavigateToRegisterPage());
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        Email = string.Empty;
        Password = string.Empty;
    }

    private async Task Login()
    {
        try
        {
            // Set the current user in the app state
            _appState.CurrentUser = new Models.User()
            {
                Email = Email,
                Password = Password
            };
            
            // Sign in with email and password to Supabase
            var response = await _supabaseClient.Auth.SignIn(Email, Password);
            
            // go to articles page if login is successful
            await Shell.Current.GoToAsync("//ArticlesPage");
        }
        // Handle invalid email or password error from Supabase
        catch (Supabase.Gotrue.Exceptions.GotrueException e)
        {
            Console.WriteLine(e);
            var errorData = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Message);

            if (errorData.ContainsKey("error") && errorData["error"] == "invalid_grant")
            {
                await Shell.Current.DisplayAlert("Error", "Invalid email or password.", "OK");
            } 
        } 
        // Handle other exceptions
        catch (Exception e)
        {
            Console.WriteLine($"Error Message: {e.Message}");
            await Shell.Current.DisplayAlert("Sign in failed", "Error occured. Please try again or register for an account.", "OK");
        }
    }
    
    private async Task NavigateToRegisterPage()
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}


