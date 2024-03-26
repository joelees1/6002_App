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

        if (decimal.TryParse(e.NewTextValue, out decimal value) && value > 0)
        {
            viewModel.GetType().GetProperty(propertyName).SetValue(viewModel, Math.Round(value, 2));
        }
        else
        {
            // Reset the value to 0m (decimal) if the input is invalid
            viewModel.GetType().GetProperty(propertyName).SetValue(viewModel, 0m);
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