using JL_CW_App.Models;

namespace JL_CW_App.Dtos;

public class QuoteServiceGetQuotesResponse
{
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int LastItemIndex { get; set; }
    public List<QuoteModel> Results { get; set; }
}