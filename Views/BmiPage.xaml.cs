using JL_CW_App.ViewModels;

namespace JL_CW_App.Views;

public partial class BmiPage
{
    public BmiPage()
    {
        InitializeComponent();
    }

    void EntryWeight_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as BmiPageViewModel);
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
           
            viewModel.Weight = 0;
        }
        else
        {
            try
            {
                viewModel.Weight = Convert.ToDouble((e.NewTextValue));
            }
            catch (Exception)
            {
                viewModel.Weight = 0;
            }
        }
    }

    void EntryHeight_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var viewModel = (BindingContext as BmiPageViewModel);
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            viewModel.Height = 0;
        }
        else
        {
            try
            {
                viewModel.Height = Convert.ToDouble((e.NewTextValue));
            }
            catch (Exception)
            {
                viewModel.Height = 0;
            }
          

        }
    }
}
