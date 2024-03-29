using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JL_CW_App.Converters;

/*
 * unused converter to take json string and convert it to a formatted DateTime object,
 * doesnt work
 */
public class DateTimeConverter : DateTimeConverterBase
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            string dateStr = (string)reader.Value;
            if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                // Log error if parsing fails
                Console.WriteLine("Failed to parse DateTime: " + dateStr);
            }
        }
        // Return existing value if parsing fails
        return existingValue;
    }
}
