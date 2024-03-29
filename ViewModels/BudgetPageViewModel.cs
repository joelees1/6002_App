using System.Collections.ObjectModel;
using System.Windows.Input;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using MauiMicroMvvm;
using Microcharts;

namespace JL_CW_App.ViewModels;

public partial class BudgetPageViewModel : BaseViewModel
{
    private readonly IAppState _appState;
    private readonly IDatabaseService _databaseService;
    public ICommand DeleteBudgetCommand { get; set; }
    public Budget Budget
    {
        get => Get<Budget>();
        set => Set(value);
    } // Budget object to store the budget
    public DonutChart Chart
    {
        get => Get<DonutChart>();
        set => Set(value);
    }
    public ObservableCollection<BudgetItem> BudgetItems
    {
        get => Get<ObservableCollection<BudgetItem>>();
        set
        {
            Set(value);
            OnPropertyChanged();
        }
    }

    public BudgetPageViewModel(ViewModelContext context, IAppState appState, IDatabaseService databaseService) : base(context)
    {
        _appState = appState;
        _databaseService = databaseService;
        DeleteBudgetCommand = new Command(async () => await DeleteBudget());
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
            var totalExpenses = Budget.Rent + Budget.Food + Budget.Transport + Budget.Entertainment + Budget.Other;
            var disposableIncome = Budget.Income - totalExpenses;
            
            // convert budget attributes to entryitems
            var entries = new ObservableCollection<ChartEntry>
            {
                new ((float)disposableIncome)
                {
                    Label = "Disposable Income",
                    ValueLabel = disposableIncome.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#5E93EC")
                },
                new ((float)Budget.Rent)
                {
                    Label = "Rent",
                    ValueLabel = Budget.Rent.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#55555B")
                },
                new ((float)Budget.Food)
                {
                    Label = "Food",
                    ValueLabel = Budget.Food.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#7395AE")
                },
                new ((float)Budget.Transport)
                {
                    Label = "Transportation",
                    ValueLabel = Budget.Transport.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#557A95")
                },
                new ((float)Budget.Entertainment)
                {
                    Label = "Entertainment",
                    ValueLabel = Budget.Entertainment.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#B1A296")
                },
                new ((float)Budget.Other)
                {
                    Label = "Other",
                    ValueLabel = Budget.Other.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#1A4FC0")
                }
            };
        
            Chart = new DonutChart()
            {
                IsAnimated = true,
                Entries = entries,
                LabelTextSize = 30f,
                LabelMode = LabelMode.RightOnly,
                AnimationDuration = new TimeSpan(0, 0, 2)
            };
            
            // get percentages of each budget item of income
            BudgetItems = new ObservableCollection<BudgetItem>
            {
                new () { Category = "Disposable Income", Amount = disposableIncome, IncomePercentage = Math.Round(disposableIncome / Budget.Income * 100)},
                new () { Category = "Rent", Amount = Budget.Rent, IncomePercentage = Math.Round(Budget.Rent / Budget.Income * 100)},
                new () { Category = "Food", Amount = Budget.Food, IncomePercentage = Math.Round(Budget.Food / Budget.Income * 100)},
                new () { Category = "Transport", Amount = Budget.Transport, IncomePercentage = Math.Round(Budget.Transport / Budget.Income * 100)},
                new () { Category = "Entertainment", Amount = Budget.Entertainment, IncomePercentage = Math.Round(Budget.Entertainment / Budget.Income * 100)},
                new () { Category = "Other", Amount = Budget.Other, IncomePercentage = Math.Round(Budget.Other / Budget.Income * 100)}
            };
        }
        catch (Exception e)
        {
            // If no budget exists, create empty objectsjosephlees79@gmail.com  password
            Budget = new Budget();
            var entries = new ObservableCollection<ChartEntry> { };
            Chart = new DonutChart() { Entries = entries };
            BudgetItems = new ObservableCollection<BudgetItem> { new () { Category = "N/A", Amount = 0, IncomePercentage = 0}, };
            Console.WriteLine(e); 
            await Shell.Current.DisplayAlert("Error", "Error No Budget Exists", "OK");
            await Shell.Current.GoToAsync("//CreateBudgetPage");
        }
    }
    
    private async Task DeleteBudget()
    {
        try
        {
            // Delete the budget from the database using the users email
            await _databaseService.DeleteBudget(_appState.CurrentUser.Email);
            await Shell.Current.DisplayAlert("Success", "Budget Deleted", "OK");
            await Shell.Current.GoToAsync("//ArticlesPage");
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            await Shell.Current.DisplayAlert("Error", "Error Deleting Budget", "OK");
        }
    }
}