using System.Diagnostics;
using System.Text.Json;
using JL_CW_App.Dtos;
using JL_CW_App.Interfaces;
using JL_CW_App.Models;

namespace JL_CW_App.Services;

public class NewsApiService : IArticleService
{
    private readonly HttpClient _client = new();
    private readonly JsonSerializerOptions? _serializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    
    public async Task<List<NewsArticle>> GetArticles()
    {
        Uri uri = new Uri(string.Concat(
            Constants.RestEndpointBase, 
            Constants.Endpoints.News, 
            "?apiKey=", AppConfig.ApiKey,
            "&q=Student&country=gb&language=en&category=business"));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<NewsApiServiceGetArticlesResponse>(content, _serializerOptions);
                return dto.Results;
            }
            return new List<NewsArticle>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return new List<NewsArticle>();
        }
    }
}