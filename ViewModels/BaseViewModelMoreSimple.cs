using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JL_CW_App.ViewModels;

public class BaseViewModelMoreSimple : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public BaseViewModelMoreSimple()
    {
    }
}