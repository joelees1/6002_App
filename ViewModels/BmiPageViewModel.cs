using System.Windows.Input;
using MauiMicroMvvm;
using JL_CW_App.Interfaces;

namespace JL_CW_App.ViewModels
{
    public class BmiPageViewModel : BaseViewModel
    {
        private readonly IQuoteService _quoteService;
        public ICommand CalculateBmiCommand { get; set; }
        public ICommand NavigateToClassicMauiPageCommand { get; set; }
        public double Bmi
        {
            get => Get<double>();
            set =>  Set(value);
        }

        public double Height
        {
            get => Get<double>();
            set
            {
                Set(value);
                (CalculateBmiCommand as Command).ChangeCanExecute();
            }
        }

        public double Weight 
        {   
            get => Get<double>(); 
            set
            {
                Set(value);
                (CalculateBmiCommand as Command).ChangeCanExecute();
            }
        }


        public BmiPageViewModel(ViewModelContext context, IQuoteService quoteService) : base(context)
        {
            _quoteService = quoteService;
            CalculateBmiCommand = new Command(execute: CalculateBmi, canExecute: CalculateBmiShouldBeEnabled);
            NavigateToClassicMauiPageCommand = new Command(execute: async () => await NavigateToClassicMauiPage());
        }

        private async Task NavigateToClassicMauiPage()
        {
            await Shell.Current.GoToAsync("/ClassicMauiPage");
        }

        private bool CalculateBmiShouldBeEnabled()
        {
            return Weight != 0 && Height != 0;
        }

        private void CalculateBmi()
        {
            var cmToMeters = Height / 100;

            Bmi = Math.Round((Weight / (cmToMeters * cmToMeters)), 2);
        }
    }
}

