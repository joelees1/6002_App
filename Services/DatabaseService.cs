using JL_CW_App.Interfaces;
using JL_CW_App.Models;
using Supabase;

namespace JL_CW_App.Services;

// Database service to interact with the Supabase database budget table
public class DatabaseService : IDatabaseService
{
    private readonly Client _supabaseClient;
    
    public DatabaseService()
    {
        // Create a new Supabase client
        _supabaseClient = new Client(AppConfig.SupabaseUrl, AppConfig.SupabaseKey);
    }
    
    // Get the budget from the database
    public async Task<Budget> GetBudget(string email)
    {
        // Get the budget from the database using the users email
        var response = await _supabaseClient.From<Budget>().Where(x => x.User == email).Get();
        // Return the first budget object
        return response.Models.First();
    }

    // Create a new budget
    public async Task SaveBudget(Budget budget)
    {
        // Insert the budget into the database using the budget model
        await _supabaseClient.From<Budget>().Insert(budget);
    }
    
    // Delete a budget
    public async Task DeleteBudget(string email)
    {
        // Delete the budget from the database using the user email
        await _supabaseClient.From<Budget>().Where(x => x.User == email).Delete();
    }
}