namespace JL_CW_App.Models;

// BudgetItem class to store the category, amount, and income percentage of each budget category
public class BudgetItem
{
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public decimal IncomePercentage { get; set; } 
}