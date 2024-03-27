using System.Globalization;

namespace JL_CW_App.Converters;

public class DescriptionConverter : IValueConverter
{
    // This converter is used to shorten the description of an article
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var text = value as string;

        int maxLength = 30;
        try { maxLength = System.Convert.ToInt32(parameter); } catch { }

        if (string.IsNullOrEmpty(text)) // Check for null or empty
        {
            return "";  // Or a placeholder string if preferred 
        } 
        
        return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException(); // We likely don't need to convert back
    }
}
