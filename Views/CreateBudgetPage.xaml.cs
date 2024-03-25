namespace JL_CW_App.Views;

public partial class CreateBudgetPage
{
    public CreateBudgetPage()
    {
        InitializeComponent();
    }
    
    private void HandleInputValidation(object sender, TextChangedEventArgs e, string propertyName)
    {
        var viewModel = BindingContext as ViewModels.CreateBudgetPageViewModel;

        if (double.TryParse(e.NewTextValue, out double value) && value > 0)
        {
            viewModel.GetType().GetProperty(propertyName).SetValue(viewModel, Math.Round(value, 2));
        }
        else
        {
            viewModel.GetType().GetProperty(propertyName).SetValue(viewModel, -1);
        }
    }
    
    private void Income_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Income"); 
    }

    private void Rent_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Rent"); 
    }
    
    private void Food_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Food"); 
    }
    
    private void Transport_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Transportation"); 
    }
    
    private void Entertainment_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Entertainment"); 
    }
    
    private void Other_TextChanged(Object sender, TextChangedEventArgs e)
    {
        HandleInputValidation(sender, e, "Other"); 
    }

}