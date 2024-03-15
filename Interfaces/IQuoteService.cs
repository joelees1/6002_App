using JL_CW_App.Models;

namespace JL_CW_App.Interfaces
{
    public interface IQuoteService
    {
        public Task<List<Models.QuoteModel>> GetQuotes();
        public Task<QuoteModel?> GetQuote();
        public Task<bool> SaveQuote(QuoteModel model);

    }
}