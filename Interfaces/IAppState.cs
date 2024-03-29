using JL_CW_App.Models;

namespace JL_CW_App.Interfaces;

// Interface for the AppState, which is used to store the current user information
public interface IAppState
{
    public User CurrentUser { get; set; }
}

