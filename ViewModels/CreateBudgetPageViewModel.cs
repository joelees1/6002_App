using System.Windows.Input;
using JL_CW_App.Models;
using MauiMicroMvvm;

namespace JL_CW_App.ViewModels;

public class CreateBudgetPageViewModel : BaseViewModel
{
    public Budget Budget { get; set; } = new(); 
    public ICommand CreateBudgetCommand { get; set; }
    public double Income
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public double Rent
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public double Food
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public double Transportation
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public double Entertainment
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    public double Other
    {
        get => Get<double>();
        set
        {
            Set(value);
            (CreateBudgetCommand as Command)?.ChangeCanExecute();
        }
    }
    
    public CreateBudgetPageViewModel(ViewModelContext context): base(context)
    {
        //CreateBudgetCommand = new Command(async () => await CreateBudget(), 
        //  () => Income > 0 && Rent > 0 && Food > 0 && Transportation > 0 && Entertainment > 0 && Other > 0);
        CreateBudgetCommand = new Command(async () => await CreateBudget(), 
            () => IsBudgetValid()); 
    }
    
    private bool IsBudgetValid()
    {
        return Income > 0 && Rent > 0 && Food > 0 && Transportation > 0 && Entertainment > 0 && Other > 0;
    }
    
    private async Task CreateBudget()
    {
        try
        {
            // Create the budget
            Budget.Income = Income;
            Budget.Rent = Rent;
            Budget.Food = Food;
            Budget.Transportation = Transportation;
            Budget.Entertainment = Entertainment;
            Budget.Other = Other;
        
            // Save the budget
        
            await Shell.Current.DisplayAlert("Success", "Budget Created", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            await Shell.Current.DisplayAlert("Error", "Failed to create budget", "OK");
        }
    }
}