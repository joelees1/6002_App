using Microcharts;

namespace JL_CW_App.Views;

public partial class BudgetPage
{
    private ChartEntry[] entries = new[]
    {
        new ChartEntry(212)
        {
            Label = "January",
            ValueLabel = "212",
            Color = SkiaSharp.SKColor.Parse("#266489")
        },
        new ChartEntry(248)
        {
            Label = "February",
            ValueLabel = "248",
            Color = SkiaSharp.SKColor.Parse("#68B9C0")
        },
        new ChartEntry(514)
        {
            Label = "March",
            ValueLabel = "514",
            Color = SkiaSharp.SKColor.Parse("#90D585")
        },
        new ChartEntry(895)
        {
            Label = "April",
            ValueLabel = "895",
            Color = SkiaSharp.SKColor.Parse("#90D585")
        }
    };
    
    public BudgetPage()
    {
        InitializeComponent();
        ChartView.Chart = new PieChart()
        {
            IsAnimated = true,
            Entries = entries
        };
    }
}