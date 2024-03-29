namespace JL_CW_App.Models;

// User model for the login and register forms & app state
public class User
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}