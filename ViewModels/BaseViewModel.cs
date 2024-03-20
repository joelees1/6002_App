using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiMicroMvvm;

namespace JL_CW_App.ViewModels
{
    public class BaseViewModel : MauiMicroViewModel
    {
        public new  event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public BaseViewModel(ViewModelContext context) : base(context)
        {
        }
    }
}

