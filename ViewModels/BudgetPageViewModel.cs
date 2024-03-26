using System.Windows.Input;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using JL_CW_App.Views;
using MauiMicroMvvm;

namespace JL_CW_App.ViewModels;

public partial class BudgetPageViewModel : BaseViewModel
{
    private readonly IAppState _appState;
    private readonly IDatabaseService _databaseService;

    public Budget Budget
    {
        get => Get<Budget>();
        set => Set(value);
    }
    public ICommand NavigateToCreateBudgetPageCommand { get; set; }

    public BudgetPageViewModel(ViewModelContext context, IAppState appState, IDatabaseService databaseService) : base(context)
    {
        _appState = appState;
        _databaseService = databaseService;
        NavigateToCreateBudgetPageCommand = new Command(async () => await NavigateToCreateBudgetPage());
    }
    
    public override async void OnAppearing()
    {
        base.OnAppearing();
        await GetBudget();
    }
    
    private async Task GetBudget()
    {
        try
        {
            // Get the budget from the database using the email
            Budget = await _databaseService.GetBudget(_appState.CurrentUser.Email);
        }
        catch (Exception e)
        {
            Budget = new Budget();
            Console.WriteLine(e); 
            await Shell.Current.DisplayAlert("Error", "Error No Budget Exists", "OK");
        }
    }
    
    private async Task NavigateToCreateBudgetPage()
    {
        await Shell.Current.GoToAsync(nameof(CreateBudgetPage));
    }
}