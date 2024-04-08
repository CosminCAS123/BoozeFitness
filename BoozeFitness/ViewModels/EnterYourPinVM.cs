using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private NavigationVM nav;
        private bool first_time_entering = true;
        public EnterYourPinVM(string username , NavigationVM navigationVM)
        {
            this.nav = navigationVM;
           
            var canExecute = this.WhenAnyValue(x => x.Pin , 
                (pin) =>
                {
                    if (string.IsNullOrEmpty(pin))
                    {
                        if (first_time_entering) first_time_entering = false;
                        else Error_Label = ErrorClass.PIN_IS_EMPTY_ERROR;
                        return false;
                    }
                    if (!pin.All(char.IsDigit))
                    {
                        Error_Label = ErrorClass.PIN_CONTAINS_OTHER_CHAR;
                        return false;
                    }
                    if (pin.Length < 6) return false;
                    Error_Label = ErrorClass.NO_ERROR;
                    return true;
                });
            CreateAccountCommand = ReactiveCommand.Create(createAccountCmd , canExecute);
           
        }
        private void createAccountCmd()
        {
            //create the user and add it into the db


        }

    }
}
