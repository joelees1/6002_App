using Postgrest.Attributes;
using Postgrest.Models;

namespace JL_CW_App.Models;

[Table("Budgets")]
public class Budget : BaseModel
{
    [Column("User")]
    public string? User { get; set; }
    [Column("Income")]
    public decimal Income { get; set; }
    [Column("Rent")]
    public decimal Rent { get; set; }
    [Column("Food")]
    public decimal Food { get; set; }
    [Column("Transport")]
    public decimal Transport { get; set; }
    [Column("Entertainment")]
    public decimal Entertainment { get; set; }
    [Column("Other")]
    public decimal Other { get; set; }
}