using Postgrest.Attributes;

namespace JL_CW_App.Models
{
    [Table("Auth")]
    public class User
    {
        //[PrimaryKey("id")]
        //public int Id { get; set; }
        
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        
        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }
}