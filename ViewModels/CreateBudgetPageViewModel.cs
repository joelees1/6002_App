using System.Windows.Input;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using MauiMicroMvvm;

namespace JL_CW_App.ViewModels;

public class CreateBudgetPageViewModel : BaseViewModel
{
    private readonly IAppState _appState;
    private readonly IDatabaseService _databaseService;
    
    public Budget Budget { get; set; } = new(); 
    public ICommand CreateBudgetCommand { get; set; }
    public decimal Income
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public decimal Rent
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public decimal Food
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public decimal Transportation
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public decimal Entertainment
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public decimal Other
    {
        get => Get<decimal>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    
    public CreateBudgetPageViewModel(ViewModelContext context, IAppState appState, IDatabaseService databaseService): base(context)
    {
        _appState = appState; 
        _databaseService = databaseService;
        CreateBudgetCommand = new Command(async () => await CreateBudget(), 
            () => IsBudgetValid()); 
    }
    
    private bool IsBudgetValid() // Check if all fields are filled and greater than 0
    {
        return Income > 0 && Rent > 0 && Food > 0 && Transportation > 0 && Entertainment > 0 && Other > 0;
    }
    
    private async Task CreateBudget() // Save the budget to the database
    {
        try
        {
            // Create the budget object
            Budget.User = _appState.CurrentUser.Email;
            Budget.Income = Income;
            Budget.Rent = Rent;
            Budget.Food = Food;
            Budget.Transport = Transportation;
            Budget.Entertainment = Entertainment;
            Budget.Other = Other;
        
            // Save the budget using the database service
            await _databaseService.SaveBudget(Budget);
            await Shell.Current.DisplayAlert("Success", "Budget Created", "OK");
            await Shell.Current.GoToAsync("//BudgetPage");
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            await Shell.Current.DisplayAlert("Error", "Failed to create budget or one already exists", "OK");
        }
    }
}