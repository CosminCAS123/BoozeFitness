using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class EnterYourPinVM : ViewModelBase
    {

        /*
         Don't let the user enter more than 6 digits
         Don't let him proceed  if he doesn't have 6 digits
        
         */
        private string error_label;
        public string Error_Label
        {
            get => this.error_label;
            set => this.RaiseAndSetIfChanged(ref error_label, value);
        }
        private string _pin;
        public string Pin
        {
            get => this._pin;
            set => this.RaiseAndSetIfChanged(ref this._pin, value);
        }
        public ReactiveCommand<Unit, Unit> CreateAccountCommand { get; set; }
        private bool first_time_entering = true;
        private NavigationVM nav;
        public EnterYourPinVM(string username , NavigationVM navigationVM)
        {
            this.nav = navigationVM;
            var canExecute =  this.WhenAnyValue(x => x.Pin,
                (pass) =>
                {
                   if (string.IsNullOrEmpty(pass))
                    {
                        if (first_time_entering) first_time_entering = false;
                        else Error_Label = ErrorClass.PIN_IS_EMPTY_ERROR;
                        return false;
                    }
                    if (!pass.All(char.IsDigit))
                    {
                        Error_Label = ErrorClass.PIN_CONTAINS_OTHER_CHAR;
                        return false;
                    }
                    return true;
                });
            CreateAccountCommand = ReactiveCommand.Create();
           
        }

    }
}
