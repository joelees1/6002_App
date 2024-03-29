using JL_CW_App.Interfaces;
using JL_CW_App.Models;

namespace JL_CW_App
{
    // AppState class that implements IAppState interface and contains the CurrentUser property
    // used to store the current user's data
    public class AppState : IAppState
    {
        public User CurrentUser { get; set; } = new();
    }
}

