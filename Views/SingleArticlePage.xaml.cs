using JL_CW_App.ViewModels;

namespace JL_CW_App.Views;

public partial class SingleArticlePage
{
    public SingleArticlePage(SingleArticleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
