using JL_CW_App.Models;

namespace JL_CW_App.Interfaces
{
    public interface IAppState
    {
        public User CurrentUser { get; set; }
    }
}

