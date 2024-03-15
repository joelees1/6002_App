using JL_CW_App.Models;

namespace JL_CW_App.Interfaces
{
    public interface IDatabaseService
    {
        Task<List<QuoteModel>> GetQuotes();
        Task<int> SaveQuote(QuoteModel quoteModel);
        Task<int> EditQuote(QuoteModel quoteModel);
        Task<int> RemoveQuote(string quoteModelId);
    }
}