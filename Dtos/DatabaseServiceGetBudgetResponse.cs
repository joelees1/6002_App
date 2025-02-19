using JL_CW_App.Models;

namespace JL_CW_App.Dtos;

public class DatabaseServiceGetBudgetResponse
{
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int LastItemIndex { get; set; } 
    
    // get a budget back
    public List<Budget> Results { get; set; }
}