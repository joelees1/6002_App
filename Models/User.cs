using Postgrest.Attributes;

namespace JL_CW_App.Models
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}