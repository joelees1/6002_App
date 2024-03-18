using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;
using JL_CW_App.Views;
using Microsoft.Maui.Controls;

namespace JL_CW_App.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IAppState _appState;

        public ICommand NavigateToMainUiCommand { get; set; }
        public ICommand ValidateCommand => new Command(Validate);

        public string Username
        {
            get => Get<string>();
            set
            {
                Set(value);
                (NavigateToMainUiCommand as Command).ChangeCanExecute();
            }
        }

        public string Password
        {
            get => Get<string>();
            set
            {
                Set(value);
                (NavigateToMainUiCommand as Command).ChangeCanExecute();
            }
        }

        public LoginPageViewModel(ViewModelContext context, IAppState appState): base(context)
        {
            NavigateToMainUiCommand = new Command(execute: async () => await NavigateToMainUI(),
                () => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password));
            _appState = appState;
          
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            Username = string.Empty;
            Password = string.Empty;
        }

        private async Task NavigateToMainUI()
        {
            _appState.CurrentUser = new Models.User()
            {
                Username = Username,
                Password = Password
            };
            await Shell.Current.GoToAsync("//ArticlesPage");
        }

        private Command validateCommand;

        private void Validate()
        {
            //some validation
        }
    }
}

