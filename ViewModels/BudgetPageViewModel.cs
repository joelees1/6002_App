using System.Windows.Input;
using JL_CW_App.Views;

namespace JL_CW_App.ViewModels;

public class BudgetPageViewModel
{
    public ICommand NavigateToCreateBudgetPageCommand { get; set; }

    public BudgetPageViewModel()
    {
        NavigateToCreateBudgetPageCommand = new Command(async () => await NavigateToCreateBudgetPage());
    }
    
    private async Task NavigateToCreateBudgetPage()
    {
        await Shell.Current.GoToAsync(nameof(CreateBudgetPage));
    }
}