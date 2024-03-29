using System.Globalization;

namespace JL_CW_App.Converters;

// Convert the percentage value to a color that is used for the budget percentage text color
public class PercentageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var curentValue = (decimal)value;
        return curentValue switch
        {
            0 => Colors.Black,
            <= 20 => Colors.Green,
            > 20 and < 51 => Colors.Coral,
            _ => Colors.Red
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}