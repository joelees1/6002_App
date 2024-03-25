using JL_CW_App.Models;

namespace JL_CW_App.Interfaces
{
    public interface IDatabaseService
    {
        //Task<Budget> GetBudget(string email);
        Task SaveBudget(Budget budget);
        //Task<Budget> EditBudget(Budget budget);
        //Task<Budget> DeleteBudget(string email);
    }
}