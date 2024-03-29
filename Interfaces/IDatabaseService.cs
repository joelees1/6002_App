using JL_CW_App.Models;

namespace JL_CW_App.Interfaces;

// Interface for the DatabaseService, which is responsible for handling the supabase budget operations
public interface IDatabaseService
{
    Task<Budget> GetBudget(string email); // Get the budget for a user
    Task SaveBudget(Budget budget); // Save the budget for a user
    //Task<Budget> EditBudget(Budget budget);
    Task DeleteBudget(string email); // Delete a user's budget
}
