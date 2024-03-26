using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using JL_CW_App.Views;
using MauiMicroMvvm;

namespace JL_CW_App.ViewModels;

public partial class BudgetPageViewModel : BaseViewModel
{
    private readonly IAppState _appState;
    private readonly IDatabaseService _databaseService;
    
    public Budget Budget { get; set; } = new();
    public ICommand NavigateToCreateBudgetPageCommand { get; set; }

    public BudgetPageViewModel(ViewModelContext context, IAppState appState, IDatabaseService databaseService) : base(context)
    {
        _appState = appState; 
        _databaseService = databaseService;
        //GetBudget();
        NavigateToCreateBudgetPageCommand = new Command(async () => await NavigateToCreateBudgetPage());
    }
    
    [RelayCommand]
    public async Task GetBudget()
    {
        try
        {
            // Get the budget from the database using the email
            Budget = await _databaseService.GetBudget(_appState.CurrentUser.Email);
            Console.WriteLine(Budget);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async Task NavigateToCreateBudgetPage()
    {
        await Shell.Current.GoToAsync(nameof(CreateBudgetPage));
    }
}