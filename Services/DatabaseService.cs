using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using Supabase;

namespace JL_CW_App.Services;

public class DatabaseService : IDatabaseService
{
    private readonly Client _supabaseClient;
    
    public DatabaseService()
    {
        _supabaseClient = new Client(AppConfig.SupabaseUrl, AppConfig.SupabaseKey);
    }
    
    // Get the budget from the database
    public async Task<Budget> GetBudget(string email)
    {
        // Get the budget from the database using the email
        var response = await _supabaseClient.From<Budget>().Where(x => x.User == email).Get();
        // Return the budget object
        return response.Models.First(); // Return the first budget
    }

    // Create a new budget
    public async Task SaveBudget(Budget budget)
    {
        // Insert the budget into the database from the budget object
        await _supabaseClient.From<Budget>().Insert(budget);
    }
}