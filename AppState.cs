using JL_CW_App.Interfaces;
using JL_CW_App.Models;

namespace JL_CW_App
{
    public class AppState : IAppState
    {
        public User CurrentUser { get; set; } = new();
    }
}

